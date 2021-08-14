const circleGameApiClient = (() => {
    const basePath = 'https://circlegameapi.azurewebsites.net/api'

    const getScores = () => 
        fetch(`${basePath}/Score`).then(res => res.json())

    const getAverage = () => 
        fetch(`${basePath}/Score/Average`).then(res => res.json())

    const getMedian = () => 
        fetch(`${basePath}/Score/Median`).then(res => res.json())

    return {
        getScores,
        getAverage,
        getMedian
    }
})()
