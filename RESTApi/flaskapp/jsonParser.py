import json

class JsonParser():
    def __init__(self, jsonFilePath):
        self.file_path = jsonFilePath
        self.data = None

    def parse(self):
        try:
            with open(self.file_path, "r") as read_file:
                self.data = json.load(read_file)
        except:
            return False

    def get_item_by_id(self, id):
        if self.data is None:
            return ""
        for exhibit in self.data["exhibits"]:
            if exhibit["id"] == int(id):
                return str(exhibit)
        return ""

    def get_value_by_key(self, id, key):
        if self.data is None:
            return ""
        for exhibit in self.data["exhibits"]:
            if exhibit["id"] == int(id):
                if key in exhibit:
                    return exhibit[key]
        return ""
            
