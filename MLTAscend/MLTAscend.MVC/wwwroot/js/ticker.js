var button = $('#getTicker');

button.click(function () {
  var symbol = $('#symbol').val();
  var day = $('#date').val();

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

      var tickerData = {
        ticker: symbol,
        date: day,
        open: daily[day]["1. open"],
        high: daily[day]["2. high"],
        low: daily[day]["3. low"],
        close: daily[day]["4. close"],
        volume: daily[day]["5. volume"]
      };

      $.ajax({
        url: '@Url.Action("ProcessData", "User")',
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ ticker: tickerData }),
        success: function (response) {
          response ? alert("It worked!") : alert("It didn't work.");
        }
      });
    })
    .catch(error => console.log('error is', error));
})