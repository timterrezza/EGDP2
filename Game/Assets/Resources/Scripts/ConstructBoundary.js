var mapAsset : TextAsset;
var wallPrefab : Transform;
var blackTile : Transform;
var whiteTile : Transform;

//map.length = 8

var white = true;
//tile y value = -6.239934

function Awake () {
    var map = mapAsset.text.Split ("\n"[0]);
    var v = new Vector3 ();
    var t = new Vector3 ();
    v.y = 5.5;
    t.y = 0;
    var j_off = map.length / 50.0;
    for (var j = 0; j < map.length; j ++) {
    	// * 4 = 4 meters between the center of each wall
        v.z = (map.length - j - j_off + 4) * 4;
        t.z = v.z;
        var i_off = map[j].length / 20.0;
        for (var i = 0; i < map[j].length; i ++) {
        	//* 4 = 4 meters between the center of each wall
            v.x = (i - i_off - 0.1) * 4;
            t.x = v.x;
            if (map[j][i] == "X") {
                Instantiate (wallPrefab, v, Quaternion.identity);
            }
            if(white == true)	{
            	Instantiate (whiteTile, t, Quaternion.identity);
            	white = false;
            	if(i == map[j].Length - 1)
            		white = true;
            }
            else	{
            	Instantiate (blackTile, t, Quaternion.identity);
            	white = true;
            	if(i == map[j].Length - 1)
            		white = false;
            }
        }
    }
}