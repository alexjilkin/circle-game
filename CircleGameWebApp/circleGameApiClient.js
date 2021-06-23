const circleGameApiClient = (() => {
    const getScores = () => 
        fetch('http://localhost:5000/api/HighScore').then(res => res.json())
    

    return {
        getScores
    }
})()