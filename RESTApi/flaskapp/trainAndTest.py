import os
import subprocess
    
def trainOrTest(testImagePath):
    graph = os.path.join(os.getcwd(), "flaskapp","tf_files","retrained_graph.pb")
    if os.path.isfile(graph):
        print "testing..."
        # label_image.py from:https://codelabs.developers.google.com/codelabs/tensorflow-for-poets/#0
        var = subprocess.check_output("python flaskapp/label_image.py --graph=" + graph + " --image="+ testImagePath, shell=True)
        objectId = var.split("\n")
        for char in objectId:
            if char.isdigit():
                objectId = char
                return objectId
            return ""
    else:
        print "training..."
        training_path = os.path.join(os.getcwd(), "flaskapp","images")
        # train_image.py from:https://codelabs.developers.google.com/codelabs/tensorflow-for-poets/#0

        os.system("python flaskapp/train_images.py --bottleneck_dir=flaskapp/tf_files/bottlenecks --how_many_training_steps=500 --model_dir=flaskapp/tf_files/models/ --summaries_dir=flaskapp/tf_files/training_summaries/${ARCHITECTURE} --output_graph=flaskapp/tf_files/retrained_graph.pb --output_labels=flaskapp/tf_files/retrained_labels.txt --image_dir=" + training_path)

def train():
    graph = os.path.join(os.getcwd(), "flaskapp","tf_files","retrained_graph.pb")
    if not os.path.isfile(graph):
        print "training..."
        training_path = os.path.join(os.getcwd(), "flaskapp","images")
        os.system("python flaskapp/train_images.py --bottleneck_dir=flaskapp/tf_files/bottlenecks --how_many_training_steps=500 --model_dir=flaskapp/tf_files/models/ --summaries_dir=flaskapp/tf_files/training_summaries/${ARCHITECTURE} --output_graph=flaskapp/tf_files/retrained_graph.pb --output_labels=flaskapp/tf_files/retrained_labels.txt --image_dir=" + training_path)