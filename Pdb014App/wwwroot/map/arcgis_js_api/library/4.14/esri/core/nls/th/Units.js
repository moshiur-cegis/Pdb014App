// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define({measures:{length:"\u0e04\u0e27\u0e32\u0e21\u0e22\u0e32\u0e27",area:"\u0e1e\u0e37\u0e49\u0e19\u0e17\u0e35\u0e48",volume:"\u0e1b\u0e23\u0e34\u0e21\u0e32\u0e15\u0e23",angle:"\u0e21\u0e38\u0e21"},units:{millimeters:{singular:"\u0e21\u0e34\u0e25\u0e25\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e21\u0e34\u0e25\u0e25\u0e34\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e21\u0e21."},centimeters:{singular:"\u0e40\u0e0b\u0e19\u0e15\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e40\u0e0b\u0e19\u0e15\u0e34\u0e40\u0e21\u0e15\u0e23",
abbr:"\u0e0b\u0e21."},decimeters:{singular:"\u0e40\u0e14\u0e0b\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e40\u0e14\u0e0b\u0e34\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e14\u0e21."},meters:{singular:"\u0e40\u0e21\u0e15\u0e23",plural:"\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e21."},kilometers:{singular:"\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23",plural:"\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e01\u0e21."},inches:{singular:"\u0e19\u0e34\u0e49\u0e27",plural:"\u0e19\u0e34\u0e49\u0e27",abbr:"\u0e43\u0e19"},
feet:{singular:"\u0e1f\u0e38\u0e15",plural:"\u0e1f\u0e38\u0e15",abbr:"\u0e1f\u0e38\u0e15"},yards:{singular:"\u0e2b\u0e25\u0e32",plural:"\u0e2b\u0e25\u0e32",abbr:"\u0e2b\u0e25\u0e32"},miles:{singular:"\u0e44\u0e21\u0e25\u0e4c",plural:"\u0e44\u0e21\u0e25\u0e4c",abbr:"\u0e44\u0e21\u0e25\u0e4c"},"nautical-miles":{singular:"\u0e44\u0e21\u0e25\u0e4c\u0e17\u0e30\u0e40\u0e25",plural:"\u0e44\u0e21\u0e25\u0e4c\u0e17\u0e30\u0e40\u0e25",abbr:"\u0e19\u0e32\u0e42\u0e19\u0e40\u0e21\u0e15\u0e23"},"us-feet":{singular:"\u0e1f\u0e38\u0e15 (\u0e2a\u0e2b\u0e23\u0e31\u0e10\u0e2f)",
plural:"\u0e1f\u0e38\u0e15 (\u0e2a\u0e2b\u0e23\u0e31\u0e10\u0e2f)",abbr:"\u0e1f\u0e38\u0e15"},"square-millimeters":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e21\u0e34\u0e25\u0e25\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e21\u0e34\u0e25\u0e25\u0e34\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e15\u0e23.\u0e21\u0e21."},"square-centimeters":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e0b\u0e19\u0e15\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e0b\u0e19\u0e15\u0e34\u0e40\u0e21\u0e15\u0e23",
abbr:"\u0e15\u0e23.\u0e0b\u0e21."},"square-decimeters":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e14\u0e0b\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e14\u0e0b\u0e34\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e15\u0e23.\u0e14\u0e21."},"square-meters":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e21\u0e15\u0e23",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e40\u0e21\u0e15\u0e23"},"square-kilometers":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23",
plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23"},"square-inches":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e19\u0e34\u0e49\u0e27",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e19\u0e34\u0e49\u0e27",abbr:"\u0e15\u0e23.\u0e19\u0e34\u0e49\u0e27"},"square-feet":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e1f\u0e38\u0e15",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e1f\u0e38\u0e15",
abbr:"\u0e15\u0e23.\u0e1f\u0e38\u0e15"},"square-yards":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e2b\u0e25\u0e32",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e2b\u0e25\u0e32",abbr:"\u0e15\u0e23.\u0e2b\u0e25\u0e32"},"square-miles":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e44\u0e21\u0e25\u0e4c",plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e44\u0e21\u0e25\u0e4c",abbr:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e44\u0e21\u0e25\u0e4c"},"square-us-feet":{singular:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e1f\u0e38\u0e15 (\u0e2a\u0e2b\u0e23\u0e31\u0e10\u0e2f)",
plural:"\u0e15\u0e32\u0e23\u0e32\u0e07\u0e1f\u0e38\u0e15 (\u0e2a\u0e2b\u0e23\u0e31\u0e10\u0e2f)",abbr:"\u0e15\u0e23.\u0e1f\u0e38\u0e15"},acres:{singular:"\u0e40\u0e2d\u0e40\u0e04\u0e2d\u0e23\u0e4c",plural:"\u0e40\u0e2d\u0e40\u0e04\u0e2d\u0e23\u0e4c",abbr:"\u0e40\u0e2d\u0e40\u0e04\u0e2d\u0e23\u0e4c"},ares:{singular:"\u0e40\u0e2d\u0e40\u0e04\u0e2d\u0e23\u0e4c",plural:"\u0e40\u0e2d\u0e40\u0e04\u0e2d\u0e23\u0e4c",abbr:"\u0e40\u0e2d"},hectares:{singular:"\u0e40\u0e2e\u0e04\u0e40\u0e15\u0e2d\u0e23\u0e4c",
plural:"\u0e40\u0e2e\u0e04\u0e40\u0e15\u0e2d\u0e23\u0e4c",abbr:"\u0e40\u0e2e\u0e01\u0e15\u0e32\u0e23\u0e4c"},liters:{singular:"\u0e25\u0e34\u0e15\u0e23",plural:"\u0e25\u0e34\u0e15\u0e23",abbr:"\u0e25\u0e34\u0e15\u0e23"},"cubic-millimeters":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e21\u0e34\u0e25\u0e25\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e21\u0e34\u0e25\u0e25\u0e34\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e25\u0e1a.\u0e21\u0e21."},
"cubic-centimeters":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e40\u0e0b\u0e19\u0e15\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e40\u0e0b\u0e19\u0e15\u0e34\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e25\u0e1a.\u0e0b\u0e21."},"cubic-decimeters":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e40\u0e14\u0e0b\u0e34\u0e40\u0e21\u0e15\u0e23",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e40\u0e14\u0e0b\u0e34\u0e40\u0e21\u0e15\u0e23",
abbr:"\u0e25\u0e1a.\u0e14\u0e21."},"cubic-meters":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e40\u0e21\u0e15\u0e23",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e25\u0e1a.\u0e21."},"cubic-kilometers":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e01\u0e34\u0e42\u0e25\u0e40\u0e21\u0e15\u0e23",abbr:"\u0e25\u0e1a.\u0e01\u0e21."},
"cubic-inches":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e19\u0e34\u0e49\u0e27",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e19\u0e34\u0e49\u0e27",abbr:"\u0e25\u0e1a.\u0e19\u0e34\u0e49\u0e27"},"cubic-feet":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e1f\u0e38\u0e15",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e1f\u0e38\u0e15",abbr:"\u0e25\u0e1a.\u0e1f\u0e38\u0e15"},"cubic-yards":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e2b\u0e25\u0e32",
plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e2b\u0e25\u0e32",abbr:"\u0e25\u0e1a.\u0e2b\u0e25\u0e32"},"cubic-miles":{singular:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e44\u0e21\u0e25\u0e4c",plural:"\u0e25\u0e39\u0e01\u0e1a\u0e32\u0e28\u0e01\u0e4c\u0e44\u0e21\u0e25\u0e4c",abbr:"\u0e25\u0e1a.\u0e44\u0e21\u0e25\u0e4c"},radians:{singular:"\u0e40\u0e23\u0e40\u0e14\u0e35\u0e22\u0e19",plural:"\u0e40\u0e23\u0e40\u0e14\u0e35\u0e22\u0e19",abbr:""},degrees:{singular:"\u0e2d\u0e07\u0e28\u0e32",
plural:"\u0e2d\u0e07\u0e28\u0e32",abbr:"\u00b0"}}});