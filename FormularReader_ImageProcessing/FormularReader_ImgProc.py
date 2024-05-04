import cv2
import numpy as np
import sys
import matplotlib.pyplot as plt
#import aspose.ocr as ocr
import tempfile
import shutil
import os
from PIL import Image
import pytesseract
import re

pytesseract.pytesseract.tesseract_cmd = 'C:\\Program Files\\Tesseract-OCR\\tesseract.exe'

def points_on_border(inp_rect, img_shape):
    img_w, img_h = img_shape
    box = cv2.boxPoints(inp_rect).astype(np.intp)
    rect = cv2.minAreaRect(box)
    vertices = cv2.boxPoints(rect)
    vertices = np.intp(vertices)
    points_on_border_cnt = 0
    
    for vertex in vertices:
        x, y = vertex
        if (x < 5) or (x > (img_w-5)) or (y < 5) or (y > (img_h-5)):
            points_on_border_cnt +=1
    #print(f"Points on Boarder: {points_on_border_cnt}")
    return points_on_border_cnt

def find_rectangles(img):
    img = img.copy()
    img_w, img_h = img.shape
    img_area = img_w * img_h
    blurred = cv2.GaussianBlur(img, (5, 5), 0)
    edges = cv2.Canny(blurred, 40, 180)
    """# Perform dilation
    kernel = np.ones((5, 5), np.uint8)
    dilated_image = cv2.dilate(edges, kernel, iterations=2)"""
    # detect contours
    contours, _ = cv2.findContours(
        edges.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE
    )
    approx = None
    rectangles = []
    for contour in contours:
        epsilon = 0.04 * cv2.arcLength(contour, True)
        approx = cv2.approxPolyDP(contour, epsilon, True)
        num_sides = len(approx)
        if(num_sides == 4):
            #x, y, w, h = cv2.boundingRect(approx)
            rect1 = cv2.minAreaRect(approx)
            width, height = rect1[1]
            rect_area = width * height
            if rect_area > img_area/10:
                #rectangles.append(cv2.boxPoints(rect1))
                if points_on_border(rect1, img.shape) <= 2:
                    rectangles.append(rect1)
    if rectangles.count == 0:
        print("ERROR: No rectangle recognized")
    return rectangles


def check_input_parameters(input_vec):
    if len(input_vec) < 2:
        print("Error: No path passed")
        sys.exit(1)
    else:
        return input_vec[1]
    #ToDo: Check whether there is actually a pic / input is valid path / ...


def img_adapt_for_placement_rec(img, thresh):
    # Sehr unscharf machen, damit Text nicht mehr als Formen erkannt wird.
    kernel = np.ones([5,5])/25      # 5x5-Feld Durchschnitt
    adapted_img = cv2.filter2D(img,-1,kernel)
    adapted_img[adapted_img > thresh]=255
    return adapted_img


def get_text_rec_thresh(img):
    thresh = img.mean() -40
    if thresh > 10:
        return thresh
    else:
        print("ERROR: Picture too dark!")
        sys.exit(1)


def img_adapt_for_text_rec(img):
    thresh = get_text_rec_thresh(img)
    
    proc = img.astype(float)
    proc[proc < thresh]=0
    proc[proc > thresh]=255
    proc = proc.astype(np.uint8)
    return proc

def adapt_image(img):
    # Adapt size
       
    if img.shape[0] >= 1000:
        new_width = 600
        height, width, _ = img.shape
        aspect_ratio = width / height
        new_height = int(new_width / aspect_ratio)
        img = cv2.resize(img, (new_width, new_height))
        
    # convert to float and remove color
    result_img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    #float_image = img.astype(float)
    #float_image = float_image / 255.0
    return result_img
    
    
def display_rects_on_img(img, rects):
    #function for debugging only
    for rect in rects:
        color = (0,255,0)
        thickness = 2
        box = cv2.boxPoints(rect)
        box = np.intp(box)
        cv2.drawContours(img, [box], 0, color, thickness)
        cv2.imshow('Image with Rectangle', img.copy())
        cv2.waitKey(0)
        cv2.destroyAllWindows()


def crop_rect(img, rect):
    # get the parameter of the small rectangle
    center, size, angle = rect[0], rect[1], rect[2]
    center, size = tuple(map(int, center)), tuple(map(int, size))
    # get row and col num in img
    height, width = img.shape[0], img.shape[1]
    # calculate the rotation matrix
    M = cv2.getRotationMatrix2D(center, angle, 1)
    # rotate the original image
    img_rot = cv2.warpAffine(img, M, (width, height))
    # now rotated rectangle becomes vertical, and we crop it
    img_crop = cv2.getRectSubPix(img_rot, size, center)
    return img_crop, img_rot


def is_not_horizontal(img_crop):
    h,w, = img_crop.shape
    if h > w:
        return True
    else:
        return False


def crop_img_in_segments(img, temp_directory):
    height,width = img.shape
    
    # Name field
    x1 = int(11*width/87)
    x2 = int(width-1)
    y1 = int(1*height/67)
    y2 = int(10*height/67)
    cropped_image = img[y1:y2, x1:x2]
    cv2.imwrite((temp_directory + "/FieldName.png"), cropped_image)
    
    # Place field
    x1 = int(14*width/87)
    x2 = int(width-1)
    y1 = int(10*height/67)
    y2 = int(21*height/67)
    cropped_image = img[y1:y2, x1:x2]
    cv2.imwrite((temp_directory + "/FieldPlace.png"), cropped_image)
    
    # Guess Field
    x1 = int(12*width/87)
    x2 = int(75*width/87)
    y1 = int(31*height/67)
    y2 = int(height-1)
    cropped_image = img[y1:y2, x1:x2]
    cv2.imwrite((temp_directory + "/FieldGuess.png"), cropped_image)

def split_string(input):
    substrings = re.split(r'\s+|\n+', input)
    return substrings


def reading_segments(img):
    # create working directory
    temp_directory = tempfile.mkdtemp() #"C:/Users/Roger Mattle/Downloads/TEST"
    # split image into segments
    crop_img_in_segments(img, temp_directory)
    # read Name-segment
    file_dir = temp_directory + "/FieldName.png"
    cropped_img = cv2.imread(file_dir)
    res_name = pytesseract.image_to_string(cropped_img)
    """print(f"Name: {res_name}")"""
    # read Place-segment    
    file_dir = temp_directory + "/FieldPlace.png"
    cropped_img = cv2.imread(file_dir)
    res_place = pytesseract.image_to_string(cropped_img)
    """print(f"Place: {res_place}")"""
    # read Guesses-segment    
    Numeric_only_config = r'--oem 3 --psm 6 -c tessedit_char_whitelist=0123456789'
    file_dir = temp_directory + "/FieldGuess.png"
    cropped_img = cv2.imread(file_dir)
    res_guesses = pytesseract.image_to_string(cropped_img, config=Numeric_only_config)
    """print(f"Guesses: {res_guesses}")"""

    shutil.rmtree(temp_directory)
    return [res_name, res_place, res_guesses]

def format_ouput(text):
    result = ""
    name = text[0]
    place = text[1]
    guesses = split_string(text[2])
    for guess in guesses:
        if len(guess)>0:
            result += (name + ',' + place + ',' + guess + ';')
    
    result = result.replace('\n','')
    return result
        


if __name__ == "__main__":
    #--- check input ------------------------------
    img_path = check_input_parameters(sys.argv)
    # Debug variants
    #img_path = "C:/Users/Roger Mattle/Downloads/TEST/FormularPic_Rotated1.png"
    #img_path = "C:/Users/Roger Mattle/Downloads/TEST/FormularPic_Comp.png"
    #img_path = "C:/Users/Roger Mattle/Downloads/TEST/FormularPic_Empty.png"
    #img_path = "C:/Users/Roger Mattle/Downloads/TEST/FormularPic_Hand.png"
    #img_path = "C:/Users/Roger Mattle/Downloads/TEST/FormularPic_Screen.png"
    #img_path = "C:/Users/Roger Mattle/Downloads/TEST/twisted_rect_green.png"
    
    #--- Open Picture ------------------------------
    img = cv2.imread(img_path)
    img = adapt_image(img)
    
    #--- Improve details visibility ----------------
    img_placement = img_adapt_for_placement_rec(img, 220)
    img_text = img_adapt_for_text_rec(img)
    
    """cv2.namedWindow('Detect Placement', cv2.WINDOW_NORMAL)
    cv2.namedWindow('Detect text', cv2.WINDOW_NORMAL)
    cv2.imshow('Detect Placement', img_placement)
    cv2.imshow('Detect text', img_text)
    cv2.waitKey(0)
    cv2.destroyAllWindows()"""
    
    # find patterns
    rectangles = find_rectangles(img_placement)
    #display_rects_on_img(img_placement, rectangles)
    #print(rectangles)
    # crop image
    if len(rectangles) > 1:
        print("ERROR: More Rectangles recognized")
        sys.exit(1)
    else:
        if len(rectangles) == 0:
            print("ERROR: No Rectangles recognized")
            sys.exit(1)
        
    img_crop, img_rot = crop_rect(img_text, rectangles[0])
    
    if is_not_horizontal(img_crop):
        img_crop = cv2.transpose(img_crop)
        img_crop = cv2.flip(img_crop, 1)
    
    # apply text recogniton
    texts = reading_segments(img_crop)
    
    # prepare output
    result = format_ouput(texts)
    print(result)
    