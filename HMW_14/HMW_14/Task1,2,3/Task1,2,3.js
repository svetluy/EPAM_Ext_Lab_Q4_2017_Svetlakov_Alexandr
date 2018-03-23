function calc() {
    delSimLetters(document.getElementById("calc").value);
}

function operation() {
    doOperation(document.getElementById("operation").value);
}

function delSimLetters(text) {
    var separators = [' ', '\t', '?', '!', ':', ';', ',', '.'];
    var str = text + "";
    var words;
    var result = str;
    var tempChar = separators[0];
    for (var i = 0; i < separators.length; i++) {
        str = str.split(separators[i]).join(tempChar);
    }
    words = str.split(tempChar);

    for (i = 0; i < words.length; i++) {
        for (var j = 0; j < words[i].length; j++) {
            for (var k = j + 1; k < words[i].length; k++) {
                if ((words[i][j] === words[i][k]) && (words[i].length > 1)) {
                    result = result.split(words[i][j]).join('');
                }
            }
        }
    }
    document.getElementById("result1").innerHTML = result;

}


function doOperation(text) {
    var str = text + '';
    str = str.split('=')[0];
    text = str;
    var separators = ['+', '-', '*', '/'];
    var numbers;
    var tempChar = separators[0];
    for (var i = 0; i < separators.length; i++) {
        str = str.split(separators[i]).join(tempChar);
    }
    numbers = str.split(tempChar);
    var op;
    var result = numbers[0];
    for (var i = 0; i < numbers.length-1; i++) {
        text = findSubstr(text);
        result = choseOp(result, numbers[i+1], op);
    }

    function findSubstr(text) {
        text = text + "";
        for (var j = 0; j < text.length; j++) {
            if (text[j] == '+' || text[j] == '-' || text[j] == '*' || text[j] == '/') {
               op = text[j];
               return text = text.substring(j+1, text.length);
            }
        }
    }

    document.getElementById("result2").innerHTML = result;
}

function choseOp(number1, number2, operation) {
    switch (operation) {
        case '+': return +number1 + +number2; 
        case '-': return +number1 - +number2; 
        case '*': return +number1 * +number2; 
        case '/': return +number1 / +number2; 
        default: return +number1; 
    }
}

function MyMoveItem() {
    var selected = $('.possible option:selected');
    selected.appendTo('.wishlist');
}

function MoveAllItem() {
    var selected = $('.possible option');
    selected.appendTo('.wishlist');
}

function RemoveItem() {
    var selected = $('.wishlist option:selected');
    selected.appendTo('.possible');
}
function RemoveAllItem() {
    var selected = $('.wishlist option');
    selected.appendTo('.possible');
}