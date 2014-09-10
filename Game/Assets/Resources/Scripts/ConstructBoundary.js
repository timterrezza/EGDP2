var mapAsset : TextAsset;
var wallPrefab : Transform;

//map.length = 8


function Awake () {
    var map = mapAsset.text.Split ("\n"[0]);
    var v = new Vector3 ();
    v.y = 5.4;
    var j_off = map.length / 50.0;
    for (var j = 0; j < map.length; j ++) {
    	// * 4 = 4 meters between the center of each wall
        v.z = (map.length - j - j_off + 4) * 4;
        var i_off = map[j].length / 20.0;
        for (var i = 0; i < map[j].length; i ++) {
        	//* 4 = 4 meters between the center of each wall
            v.x = (i - i_off - 0.1) * 4;
            if (map[j][i] == "X") {
                Instantiate (wallPrefab, v, Quaternion.identity);
            }
        }
    }
}