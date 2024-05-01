"""import easyocr
import matplotlib.pyplot as plt
import numpy as np
import cv2


cam = cv2.VideoCapture(1)
reader = easyocr.Reader(['en'],gpu = False)

while(True):

    #open Webcam
    ret, frame = cam.read()
    cv2.imshow('Webcam', frame)

    #Save Picture
    if cv2.waitKey(1) & 0xFF == ord('s'):
        cv2.imwrite('data/img.png', frame)
        print('Saved image')

        image = cv2.imread('data/img.png')
        ##sharpened_image = cv2.Laplacian(image, cv2.CV_64F)
        ##sharpened_image = np.uint8(np.absolute(sharpened_image))
        cv2.imshow("Image", image)

        result = reader.readtext(image)
        for detection in result:
            print(detection[1])


    if cv2.waitKey(1) & 0xFF == ord('q'):


        break"""
import sys

if __name__ == '__main__':
    if len(sys.argv) < 2:
            print("Error: Picture path")
            sys.exit(1)
            
    picture_path = sys.argv[1]

    #print("Directory from C#:", picture_path, ",,;")
    print("Roger Mattle,Montlingen,567;Max Muster,Musterdorf,876;Tom Müller,Kriessern,123;Kevin Haltiner,Oberriet,852;")
    sys.stdout.flush()
    #sys.exit(123)
    
    
    
    
    
    
    
    
    
    