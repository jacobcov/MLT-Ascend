var button = $('#getTicker');

button.click(function () {
  var symbol = $('#symbol').val();
  var date = $('#date').val();

  var url = 'https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=' + symbol + '&outputsize=full&datatype=json&apikey=8YPLUQI35GBY540Q';

  fetch(url)
    .then(response => {
      if (response.ok) {
        return response.json();
      } else {
        return Promise.reject('something went wrong!');
      }
    })
    .then(data => {
      var daily = data["Time Series (Daily)"];
      console.log(daily[date]["1. open"]);
      console.log(daily[date]["2. high"]);
      console.log(daily[date]["3. low"]);
      console.log(daily[date]["4. close"]);
      console.log(daily[date]["5. volume"]);
    })
    .catch(error => console.log('error is', error));
})
