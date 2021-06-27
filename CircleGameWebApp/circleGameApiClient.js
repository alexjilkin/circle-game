const circleGameApiClient = (() => {
    const basePath = 'https://circlegameapi.azurewebsites.net/api'

    const getScores = () => 
        fetch(`${basePath}/Score`).then(res => res.json())
    
    return {
        getScores
    }
})()
