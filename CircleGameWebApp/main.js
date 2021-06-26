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

    circleGameApiClient.getScores().then(res => {
        scores = res
        filteredScores = scores;
        renderScores(scores)
    })

    const input = document.getElementById('input-filter')

    input.addEventListener('input', e => {
        filterValue = e.target.value
        filteredScores = scores.filter(({name}) => name.toLowerCase().includes(filterValue.toLowerCase()))
        renderScores(filteredScores)
    });
})()

