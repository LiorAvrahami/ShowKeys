using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShowKeys {
    internal class Files_Utils {
        public const string KeyBoardMap_folder_name = "KeyBoardMaps";

        public const string KeyBoardMap_base_image_name = "image.*";

        public const string KeyBoard_Point_Map_File = "Map.json";

        public const string File_With_Selectted_Map = "Selectted.wow";

        public const string File_With_Initiators = "Initiators.wow";

        public static string get_image_file(string dir_path) {
            try {
                string image_file_name = Directory.GetFiles(dir_path, KeyBoardMap_base_image_name)[0];
                return image_file_name;
            } catch {
                return null;
            }
        }

        public static void save_to_file(Dictionary<int,List<Point>> pointMap, string keyboard_name, string image_file_path) {
            string json_to_save = JsonConvert.SerializeObject(pointMap);

            string keyboard_map_path = Path.Join(KeyBoardMap_folder_name, keyboard_name);

            Directory.CreateDirectory(keyboard_map_path);

            string path = Path.Join( KeyBoardMap_folder_name, keyboard_name, KeyBoard_Point_Map_File);
            File.WriteAllText(path, json_to_save);

            string dest_image_path = Path.Join(keyboard_map_path,Path.GetFileName(image_file_path));

            File.Copy(image_file_path, dest_image_path);
            
        }

        public static Dictionary<int, List<Point>> load_pointMap_from_file(string keyboard_name) {
            string path = Path.Join(KeyBoardMap_folder_name, keyboard_name, KeyBoard_Point_Map_File);

            string json_to_read = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<Dictionary<int, List<Point>>>(json_to_read);

        }

        public static Dictionary<int, List<Point>> load_selecttd_keyboard_pointMap() {
            string keyboard_name = Path.GetFileName(load_selected());
            if (keyboard_name == "") {
                return new Dictionary<int, List<Point>>();
            }
            return load_pointMap_from_file(keyboard_name);
        }

        public static string get_selecttd_image_file() {
            return get_image_file(load_selected());
        }

        public static void save_selected(string selectted_map_path) {
            File.WriteAllText(File_With_Selectted_Map, selectted_map_path);
        }

        public static string load_selected() {
            try {
                return File.ReadAllText(File_With_Selectted_Map);
            } catch { return ""; }
        }

        public static (List<List<int>>, List<List<string>>) get_initiators() {
            
            try {
                string json_to_read = File.ReadAllText(File_With_Initiators);

                return JsonConvert.DeserializeObject<(List<List<int>>, List<List<string>>)>(json_to_read);
            } catch {
                return (new List<List<int>>(), new List<List<string>>());
            }
        }

        public static void save_initiators(List<List<int>> key_codes, List<List<string>> key_names) {
            string json_to_write = JsonConvert.SerializeObject((key_codes, key_names));

            File.WriteAllText(File_With_Initiators, json_to_write);
        }            

        public static void DeleteDirectory(string target_dir) {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files) {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs) {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
}
