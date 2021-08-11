(function () {
    const ctx = document.getElementById('scatter').getContext('2d');
    let graph;

    circleGameApiClient.getScores().then(scores => {
        const data = scores.map((score, x) => ({
            x,
            y: score.score
        }))
        graph = new Chart(ctx, {
            type: 'scatter',
            data: {
                datasets: [{
                    label: 'Scores',
                    data
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        min: -5,
                        max: data.length + 10,
                        ticks: {
                            display: false,
                        },
                        title: 'something random'
                    },
                    y: {
                        title: 'score'
                    }
                },
                backgroundColor: 'pink'
            },
          });
    })
    
})()
