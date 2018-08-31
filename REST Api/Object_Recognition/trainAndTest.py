import os

def main(filepath):
    checkIfPicExists(filepath)

def checkIfPicExists(path):
    for dirpath, dirnames, files in os.walk(path):
        if files:
            print(dirpath, 'has files')
            trainOrTest(path, files[0])
        if not files:
            print(dirpath, 'is empty. No Image in direcotry')
    
def trainOrTest(path, testImageName):
    graph = "tf_files/retrained_graph.pb"
    if os.path.isfile(graph):
        print "testing..."
        os.system("python label_image.py --graph=" + graph + " --image="+ path + "/" + testImageName)
    else:
        print "training..."
        training_path = os.path.join(os.getcwd(), "images")
        os.system("python train_images.py --bottleneck_dir=tf_files/bottlenecks --how_many_training_steps=500 --model_dir=tf_files/models/ --summaries_dir=tf_files/training_summaries/${ARCHITECTURE} --output_graph=tf_files/retrained_graph.pb --output_labels=tf_files/retrained_labels.txt --image_dir=" + training_path)
    

if __name__=='__main__':
    #filepath = "/mnt/k/Users/Tobias/Documents/HoloMu/REST Api/flaskapp/tmp"
    main(filepath)