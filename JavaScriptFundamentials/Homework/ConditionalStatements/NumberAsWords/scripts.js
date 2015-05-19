/**
 * Created by Mastermind on 19.5.2015 ã..
 */
var result;

function showResult() {
    var first = document.getElementById('tb-first').value;

    if (parseFloat(first) < 10) {
        result = ZeroToNine(first);
    }
    else {
        if (parseFloat(first) < 20) {
            result = TenTo19(first);
        }
        else {
            if (parseFloat(first) < 100) {
                if (parseFloat(first) % 10 == 0){
                    result = TwentyTo90((Math.floor(first / 10)).toString());
                }
                else {
                    result = TwentyTo90((Math.floor(first / 10)).toString()) + ' ' + ZeroToNine((Math.floor(first % 10)).toString()).toLowerCase();
                }
            }
            else {
                if (parseFloat(first) % 100 == 0) {
                    result = ZeroToNine((Math.floor(first / 100)).toString()) + ' hundred';
                }
                else {
                    var rightPart = parseFloat(first) % 100;
                    if (rightPart > 19) {
                        if (parseFloat(rightPart) % 10 == 0){
                            result = ZeroToNine((Math.floor(first / 100)).toString()) + ' hundred and ' + TwentyTo90((Math.floor(rightPart / 10)).toString()).toLowerCase();
                        }
                        else {
                            result = ZeroToNine((Math.floor(first / 100)).toString()) + ' hundred and ' + TwentyTo90((Math.floor(rightPart / 10)).toString()).toLowerCase() + ' ' + ZeroToNine((parseFloat(rightPart % 10)).toString()).toLowerCase();
                        }
                    }
                    else {
                        if (rightPart < 10) {
                            result = ZeroToNine((Math.floor(first / 100)).toString()) + ' hundred and ' + ZeroToNine(rightPart.toString()).toLowerCase();
                        }
                        else {
                            result = ZeroToNine((Math.floor(first / 100)).toString()) + ' hundred and ' + TenTo19(rightPart.toString()).toLowerCase();
                        }
                    }
                }
            }
        }
    }



    document.getElementById('result').innerHTML = result;
}

function ZeroToNine(first) {
    var result;
    switch (first) {
        case '0':
            result = 'Zero';
            break;
        case '1':
            result = 'One';
            break;
        case '2':
            result = 'Two';
            break;
        case '3':
            result = 'Three';
            break;
        case '4':
            result = 'Four';
            break;
        case '5':
            result = 'Five';
            break;
        case '6':
            result = 'Six';
            break;
        case '7':
            result = 'Seven';
            break;
        case '8':
            result = 'Eight';
            break;
        case '9':
            result = 'Nine';
            break;
        default: break;
    }
    return result;
}

function TenTo19(first) {
    var result;
    switch (first) {
        case '10': result = 'Ten';
            break;
        case '11': result = 'Eleven';
            break;
        case '12': result = 'Twelve';
            break;
        case '13': result = 'Thirteen';
            break;
        case '14': result = 'Fourteen';
            break;
        case '15': result = 'Fifteen';
            break;
        case '16': result = 'Sixteen';
            break;
        case '17': result = 'Seventeen';
            break;
        case '18': result = 'Eighteen';
            break;
        case '19': result = 'Nineteen';
            break;
        default: break;
    }
    return result;
}

function TwentyTo90(first) {
    var result;
    switch (first) {
        case '2': result = 'Twenty';
            break;
        case '3': result = 'Thirty';
            break;
        case '4': result = 'Forty';
            break;
        case '5': result = 'Fifty';
            break;
        case '6': result = 'Sixty';
            break;
        case '7': result = 'Seventy';
            break;
        case '8': result = 'Eighty';
            break;
        case '9': result = 'Ninety';
            break;
        default: break;
    }
    return result;
}
