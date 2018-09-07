import os
import xml.etree.ElementTree as ET


class XMLParser:
    def __init__(self, xmlFilePath):
        self.xmlFilePath = xmlFilePath
        self.tree = None
        self.root = None

    def parse(self):
        if not os.path.exists(self.xmlFilePath):
            return False
        self.tree = ET.parse(self.xmlFilePath)
        self.root = self.tree.getroot()
        return True
    
    def get_item_string_by_id(self, id):
        if self.root is None:
            print ("Xml root is none, call parse function first")
            return ""
        items = self.root.findall(".//item[@id='" + id + "']")
        if len(items) != 1:
            print ("More than one item or no items found with id " + id)
            return ""

        return ET.tostring(items[0], encoding="utf-8", method="xml")