import cv2
import sys

def main(pic_path, cam):
    if cam > 2:
        print("Error: invalid camera passed")
        sys.exit(1)
    
    
    # Open the default camera (usually the first webcam)
    cap = cv2.VideoCapture(cam)

    # Check if the camera opened successfully
    if not cap.isOpened():
        print("Error: Could not open webcam")
        sys.exit(1)

    # Loop to continuously capture frames from the webcam
    while True:
        # Capture frame-by-frame
        ret, frame = cap.read()

        # Display the captured frame
        cv2.imshow('press [S] to take picture / [Q] for closing window', frame)
        key = cv2.waitKey(1)
        
        # USER Commands
        if key & 0xFF == ord('s'):                  # S = take picture
            cv2.imwrite(pic_path, frame)
            break
        if key & 0xFF == ord('q') or key == 27:     # Q | Esc = cancel
            break

    # Release the camera and close OpenCV windows
    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    if len(sys.argv) < 2:
            print("Error: No directory path passed")
            sys.exit(1)
    if len(sys.argv) < 3:
            print("Error: No camera instance passed")
            sys.exit(1)
    
    """print("first argument")
    print(sys.argv[1])
    print("second argument")
    print(sys.argv[2])"""
    
    picture_path = sys.argv[1]
    cam_instance = int(sys.argv[2])
    main(picture_path, cam_instance)