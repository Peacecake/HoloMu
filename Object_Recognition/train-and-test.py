import os

def main():
    graph = "tf_files/retrained_graph.pb"
    testImagePath = "test_images/img15.jpg" #path to the testimage
    if os.path.isfile(graph):
        print "testing..."
        os.system("python label_image.py --graph=" + graph + " --image=" + testImagePath)
    else:
        print "training..."
        os.system("python train_images.py --bottleneck_dir=tf_files/bottlenecks --how_many_training_steps=500 --model_dir=tf_files/models/ --summaries_dir=tf_files/training_summaries/${ARCHITECTURE} --output_graph=tf_files/retrained_graph.pb --output_labels=tf_files/retrained_labels.txt --image_dir=/mnt/k/Users/Tobias/Documents/HoloMu/Object_Recognition/images") #path to the training images have to be changed

if __name__=='__main__':
    main()