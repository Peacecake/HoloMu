import os

def main():
    checkIfPicExists()

def checkIfPicExists():
    for dirpath, dirnames, files in os.walk('./test_image'):
        if files:
            print(dirpath, 'has files')
            trainOrTest(files[0])
        if not files:
            print(dirpath, 'is empty. No Image in direcotry')
    
def trainOrTest(testImageName):
    graph = "tf_files/retrained_graph.pb"
    if os.path.isfile(graph):
        print "testing..."
        os.system("python label_image.py --graph=" + graph + " --image=test_image/" + testImageName)
    else:
        print "training..."
        os.system("python train_images.py --bottleneck_dir=tf_files/bottlenecks --how_many_training_steps=500 --model_dir=tf_files/models/ --summaries_dir=tf_files/training_summaries/${ARCHITECTURE} --output_graph=tf_files/retrained_graph.pb --output_labels=tf_files/retrained_labels.txt --image_dir=/mnt/k/Users/Tobias/Documents/HoloMu/Object_Recognition/images")


if __name__=='__main__':
    main()