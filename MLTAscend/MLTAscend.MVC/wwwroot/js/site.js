var table = $('table');

$('#companyName, #ticker, #date, #1d, #1w, #1mo, #3mo, #6mo, #1yr, #2yr, #5yr')
  .each(function () {

    var th = $(this),
      thIndex = th.index(),
      inverse = false;

    th.click(function () {

      table.find('td').filter(function () {

        return $(this).index() === thIndex;

      }).sortElements(function (a, b) {

        return $.text([a]) > $.text([b]) ?
          inverse ? -1 : 1
          : inverse ? 1 : -1;

      }, function () {

        return this.parentNode.parentNode;
      });

      inverse = !inverse;
    });
  });
