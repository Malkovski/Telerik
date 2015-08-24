function solve() {
    var game = false,
        winCondition = false,
        highScoreList = [],
        numberToGuess = [],
        currentPlayerName;

    function init(playerName, endCallback) {
        game = true;

        currentPlayerName = playerName;
        highScoreList.push({name: playerName, score: 0});
        console.log(highScoreList);
        while(numberToGuess.length < 4) {
            var randomNumber = Math.ceil(Math.random() * 9);
            var found = false;

            for(var i = 0; i < numberToGuess.length; i++) {
                if(numberToGuess[i]==randomNumber)
                {
                    found = true;
                    break;
                }
            }

            if(!found) {
                numberToGuess[numberToGuess.length] = randomNumber;
            }
        }
        console.log(numberToGuess);
    }


    function guess(number) {
        if (!game) {
            throw new Error('Game must be initialized first!');
        }

        if (number.toString().length !== 4) {
            throw new Error('The suggested number must be exactly 4 digit long!');
        }

        var suggestion = number.toString().split('');
        var currentResult = checkForSheepAndRams(suggestion);

        if (winCondition) {
           var player = _.find(highScoreList, function (item) {
                return item.name === currentPlayerName
            });

            player.score += 1;
            console.log(player);
        }
        console.log(currentResult);
        return currentResult;

    }

    function checkForSheepAndRams(suggestion) {
        var rams = 0,
            sheep = 0;
        console.log(suggestion);
        console.log(numberToGuess);
        for (var i = 0, leni = suggestion.length; i < leni; i += 1) {
            var currentDigit = suggestion[i];

            for (var j = 0, lenj = numberToGuess.length; j < lenj; j += 1) {
                var currentDigitToGuess = numberToGuess[j];

                if ((i === j) && (currentDigit == currentDigitToGuess)) {
                    rams += 1;
                }
                else if ((currentDigit == currentDigitToGuess)) {
                    sheep += 1;
                }
            }
        }

        if (rams === 4) {
            winCondition = true;
        }

        return {
            sheep: sheep,
            rams: rams
        }
    }

    function getHighScore(count) {

    }

    return {
        init: init,
        guess: guess,
        getHighScore: getHighScore
    }
}


module.exports = solve;

/*var a = solve();
a.init('ggg');
a.guess(2345);*/
