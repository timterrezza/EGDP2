var mapAsset : TextAsset;
var wallPrefab : Transform;
var blackTile : Transform;
var whiteTile : Transform;

//map.length = 8

var white = true;
//tile y value = -6.239934

function Awake () {
    var map = mapAsset.text.Split ("\n"[0]);
    var x = 0.0;
    var y = 5.5;
    var z = 0.0;
    for (var j = 0; j < map.length; j ++) {
    	// * 4 = 4 meters between the center of each wall
        var i_off = map[j].length / 20.0;
        for (var i = 0; i < map[j].length; i ++) {
            if (map[j][i] == "X") {
                Instantiate (wallPrefab, new Vector3(i*4, y, j*4), Quaternion.identity);
            }
            
            if(white == true)	{
            	Instantiate (whiteTile, new Vector3(i*4, 0, j*4), Quaternion.identity);
            	white = false;
            	if(i == map[j].Length - 1)
            		white = true;
            }
            else	{
            	Instantiate (blackTile, new Vector3(i*4, 0, j*4), Quaternion.identity);
            	white = true;
            	if(i == map[j].Length - 1)
            		white = false;
            }
            
        }
    }
}