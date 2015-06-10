/**
 * Created by Geogi Malkovski on 19.5.2015 ã..
 */
function transformToSomeBase(params) {

    var parts = params[0].match(/.{1,2}/g);
    var model = {};

    for (var el in parts) {
        model[parts[el]] = (el * 2).toString();
    }


    //convert ot some base!!!
    var wordInBase = parseInt(model[parts[4]] + model[parts[6]] + model[parts[1]]);

    console.log(wordInBase);
    var result = wordInBase.toString(7);
    console.log(result);
    var newResult = parseInt(result, 7);
    console.log(newResult);

}

transformToSomeBase(['asesrstsgscsxszs']);