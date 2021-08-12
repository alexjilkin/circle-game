(function () {
    const ctx = document.getElementById('scatter').getContext('2d');
    let graph;

    circleGameApiClient.getScores().then(scores => {
        const data = scores.map(({score, time}) => ({
            x: time,
            y: score
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
                plugins: {
                    tooltip: {
                        callbacks: {
                           label: function({dataIndex}) {
                              return scores[dataIndex].name;
                           }
                        }
                     }
                },
                backgroundColor: 'pink'
            },
          });
    })
    
})()
