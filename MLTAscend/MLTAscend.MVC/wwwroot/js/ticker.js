fetch('https://www.alphavantage.co/query?function=SMA&symbol=irbt&interval=daily&time_period=10&series_type=close&apikey=8YPLUQI35GBY540Q')
  .then(response => {
    if (response.ok) {
      return response.json()
    } else {
      return Promise.reject('something went wrong!')
    }
  })
  .then(data => console.log('data is', data))
  .catch(error => console.log('error is', error));