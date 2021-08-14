(function main() {
    let filterValue = '';
    let scores = [];
    let filteredScores = [];

    const  $scores = document.getElementsByClassName('scores')[0]

    function renderScores(scores) {
        $scores.innerHTML = ''
        scores.forEach(score => {
            $score = document.createElement('div')
            $score.className = 'panel-block'
            $score.innerHTML = `${score.name}: ${score.score}`
            $scores.appendChild($score);
        })
    }

    function renderMedian(median) {
        $median = document.querySelector('.median-score .value')
        $median.innerHTML = `${median}`
    }

    function renderAverage(average) {
        $median = document.querySelector('.average-score .value')
        $median.innerHTML = `${average}`
    }

    circleGameApiClient.getScores().then(res => {
        window.scores = res;
        scores = res
        filteredScores = scores;
        renderScores(scores)
    })

    circleGameApiClient.getMedian().then(median => {
        renderMedian(median)
    })

    circleGameApiClient.getAverage().then(average => {
        renderAverage(average)
    })

    const input = document.getElementById('input-filter')

    input.addEventListener('input', e => {
        filterValue = e.target.value
        filteredScores = scores.filter(({name}) => name && name.toLowerCase().includes(filterValue.toLowerCase()))
        renderScores(filteredScores)
    });
})()

