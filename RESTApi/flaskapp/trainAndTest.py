import os
import subprocess
    
def trainOrTest(testImagePath):
    graph = os.path.join(os.getcwd(), "flaskapp","tf_files","retrained_graph.pb")
    print "testImagePath "+ testImagePath
    print "graph "+ graph
    if os.path.isfile(graph):
        print "testing..."
        var = subprocess.check_output("python flaskapp/label_image.py --graph=" + graph + " --image="+ testImagePath, shell=True)
        print "var " + var
        objectId = var.split("\n")
        for char in objectId:
            if char.isdigit():
                objectId = char
                return objectId
            return "No valid id recognized"
    else:
        print "training..."
        training_path = os.path.join(os.getcwd(), "flaskapp","images")
        print "trainingpath " + training_path
        os.system("python flaskapp/train_images.py --bottleneck_dir=flaskapp/tf_files/bottlenecks --how_many_training_steps=500 --model_dir=flaskapp/tf_files/models/ --summaries_dir=flaskapp/tf_files/training_summaries/${ARCHITECTURE} --output_graph=flaskapp/tf_files/retrained_graph.pb --output_labels=flaskapp/tf_files/retrained_labels.txt --image_dir=" + training_path)

#if __name__=='__main__':
#    #filepath = "/mnt/k/Users/Tobias/Documents/HoloMu/REST Api/flaskapp/tmp"
#    #filepath = "/mnt/k/Users/Tobias/Documents/HoloMu/RESTApi/Object_Recognition/test_image/img1.jpg"
#    main(filepath)