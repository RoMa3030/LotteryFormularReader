import cv2
import sys

def main(pic_path):
    # Open the default camera (usually the first webcam)
    cap = cv2.VideoCapture(0)

    # Check if the camera opened successfully
    if not cap.isOpened():
        print("Error: Could not open webcam")
        return

    # Loop to continuously capture frames from the webcam
    while True:
        # Capture frame-by-frame
        ret, frame = cap.read()

        # Display the captured frame
        cv2.imshow('press [S] to take picture / [Q] for closing window', frame)
        key = cv2.waitKey(1)
        
        if key & 0xFF == ord('s'):
            cv2.imwrite(pic_path, frame)
            break
        
        if key & 0xFF == ord('q') or key == 27:
            break

    # Release the camera and close OpenCV windows
    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    if len(sys.argv) < 2:
            print("Error: Picture path")
            sys.exit(1)
    picture_path = sys.argv[1]
    
    main(picture_path)