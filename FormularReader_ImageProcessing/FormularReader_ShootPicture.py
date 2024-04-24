# -*- coding: utf-8 -*-
"""
Created on Fri Feb 14 08:34:36 2020

@author: birkudo
"""

import numpy as np
import cv2
import sys
import matplotlib.pyplot as plt
import time
import platform

DEFAULT_WEBCAM_ID = 0 # change here, to open your preferred webcam 

class WebcamGUI:
    WND_NAME = 'Live cam | Press ESCAPE to quit.'
    cap = None;
    def __init__(self, DEVICE_ID):
        if len(DEVICE_ID) == 1:
            DEVICE_ID = ord(DEVICE_ID)-48;
        if platform.system() == 'Windows':
            videoBackend = cv2.CAP_DSHOW
        else:
            videoBackend = cv2.CAP_ANY
        self.cap = cv2.VideoCapture(DEVICE_ID, videoBackend);
        if self.cap.isOpened():
            print('successfully opened camera device  {}'.format(DEVICE_ID))
        else:
            self.errMsg = 'ERROR: failed to open camera device {}'.format(DEVICE_ID)
            print(self.errMsg);
        cv2.namedWindow(self.WND_NAME, cv2.WINDOW_NORMAL);
        self.last_click_time = None
    
    def isRunning(self):
        if cv2.getWindowProperty(self.WND_NAME, 0) < 0:
            return(False);
        if(self.testQuitRequest()):
            return(False);
        return True;
            
    def getFrame(self):
        # Capture frame-by-frame
        ret, frame = self.cap.read()
        if frame is None:
            return(False, frame);
        else:
            return(True, frame);
            
    def displayProcessedFrame(self, data):
        if cv2.getWindowProperty(self.WND_NAME, 0) >= 0:
            cv2.imshow(self.WND_NAME,data)        
            
    def testQuitRequest(self):
        isQuitRequest = False;
        c = cv2.waitKey(10) & 0xFF
        if c == ord('q'):
            isQuitRequest = True;
        if c == 27:
            isQuitRequest = True;
        return(isQuitRequest)
    
    def __del__(self):
        # When everything done, release the capture
        self.cap.release()
        cv2.destroyAllWindows()

    
def modifyCamImageScript():
    global orig, proc
    debug = False;
    errMsg = None;
    filepath = 'ModifyCamImageScript.py'
    try:
        with open(filepath) as fp:
           line = fp.readline()
           cnt = 1
           while line:
               line = line.strip()
               if(debug):
                   print("Line {}: {}".format(cnt, line))
               # cc = compile(line,'abc','exec')
               try:
                   cc = compile('global orig, proc;\n'+line,'abc','exec')
                   eval(cc)
               except:
                   errMsg = 'Error in line {}:{}'.format(cnt,line)
                   break;
               line = fp.readline()
               cnt += 1
    except Exception as err:
        errMsg = f"{err}"
    if(debug):
        plt.imshow(proc,cmap='gray');
        plt.gcf().canvas.draw_idle();
        cv2.waitKey(100);
        a = 1;
    return(errMsg)

def get_device_id():
    """
    Creates a new argument parser.
    """
    if(len(sys.argv) > 1):
        return(sys.argv[1])
    else:
        webcam = DEFAULT_WEBCAM_ID
        if not isinstance(webcam, str):
            webcam = str(webcam)
        return(webcam) # use default camera (DEFAULT_WEBCAM_ID)



def main():
    global orig, proc

    DEIVCE_ID = get_device_id()
    
    MainWND = WebcamGUI(DEIVCE_ID);
    while(MainWND.isRunning()):
    
        isOK,frame = MainWND.getFrame();
        if not isOK:
            break;
            
        # Our operations on the frame come here
        orig = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        #MainWND.displayOriginalFrame(orig.astype(np.uint8));
        
        # make a copy of the original, if anything goes wrong
        proc = orig;
        
        # run 'ModifyCamImageScript.py'
        errMsg = modifyCamImageScript();
    
        # Display the resulting frame
        dst = proc.astype(np.uint8);
        dst = cv2.cvtColor(dst,cv2.COLOR_GRAY2BGR);
        if errMsg is not None:
            cv2.putText(dst,errMsg,(5,25),cv2.FONT_HERSHEY_COMPLEX,1,(0,0,255),2)
        MainWND.displayProcessedFrame(dst);

#-----------------------------------------------------------------------------------

import sys

if __name__ == '__main__':
    if len(sys.argv) < 2:
            print("Error: Picture path")
            sys.exit(1)
            
    picture_path = sys.argv[1]


    global orig, proc

    DEIVCE_ID = get_device_id()
    
    MainWND = WebcamGUI(DEIVCE_ID);
    while(MainWND.isRunning()):
    
        isOK,frame = MainWND.getFrame();
        if not isOK:
            break;
            
        # Our operations on the frame come here
        orig = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        #MainWND.displayOriginalFrame(orig.astype(np.uint8));
        
        # make a copy of the original, if anything goes wrong
        proc = orig;
        
        # run 'ModifyCamImageScript.py'
        errMsg = modifyCamImageScript();
    
        # Display the resulting frame
        dst = proc.astype(np.uint8);
        dst = cv2.cvtColor(dst,cv2.COLOR_GRAY2BGR);
        if errMsg is not None:
            cv2.putText(dst,errMsg,(5,25),cv2.FONT_HERSHEY_COMPLEX,1,(0,0,255),2)
        MainWND.displayProcessedFrame(dst);



    sys.stdout.flush()
    #sys.exit(123)
    
    
    
    
    
    
    
    
    
    