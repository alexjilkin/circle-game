circleGameApiClient.getScores().then(scores => {
    $scores = document.getElementsByClassName('scores')[0]

    scores.forEach(score => {
        $score = document.createElement('div')
        $score.innerHTML = `${score.name}: ${score.score}`

        $scores.appendChild($score);
    })
})