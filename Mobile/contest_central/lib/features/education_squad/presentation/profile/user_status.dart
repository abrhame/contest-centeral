import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
// import 'chart.dart';

class StatusData extends StatefulWidget {
  StatusData();

  @override
  StatusDataState createState() => StatusDataState();
}

class StatusDataState extends State<StatusData> {
  int touchedIndex = 0;
  List<Color> gradientColors = [
    Color(0xffd9e2ff),
    Color(0xffd9e2ff),
  ];
  int activeIndex = 0;
  bool showAvg = false;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(top: 10.0),
      child: Container(
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(8.0),
          border: Border.all(
            color: const Color.fromARGB(91, 207, 207, 207),
            width: 1,
          ),
          boxShadow: const [
            BoxShadow(
              color: Color.fromRGBO(149, 157, 165, 0.26),
              offset: Offset(0, 8),
              blurRadius: 6.0,
            ),
          ],
        ),
        child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    const Text(
                      "Status",
                      style: TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.bold,
                        color: Color.fromARGB(255, 107, 104, 104),
                      ),
                    ),
                    const SizedBox(height: 10),
                    // underline blue text "Conversion Rate" and black text "Ranking" in one row
                    const Row(
                      // mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Text(
                          "Conversion Rate",
                          style: TextStyle(
                            decoration: TextDecoration.underline,
                            fontSize: 16,
                            color: Color.fromARGB(255, 13, 69, 189),
                          ),
                        ),
                        SizedBox(
                          width: 70,
                        ),
                        Text(
                          "Ranking",
                          style: TextStyle(
                            fontSize: 16,
                            color: Color.fromARGB(255, 107, 104, 104),
                          ),
                        ),
                      ],
                    ),

                    const SizedBox(height: 10),
                    const Row(
                      // mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Text(
                          "Current Rate",
                          style: TextStyle(
                            fontSize: 15,
                            // underlined

                            color: Color.fromARGB(255, 70, 71, 74),
                          ),
                        ),
                        SizedBox(
                          width: 50,
                        ),
                        Text(
                          "0.767",
                          style: TextStyle(
                            fontSize: 15,
                            color: Color.fromARGB(255, 25, 208, 46),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(height: 10),
                    Padding(
                      padding:
                          const EdgeInsets.only(left: 5.0, top: 0, bottom: 0),
                      child: AspectRatio(
                        aspectRatio: 1.2,
                        child: Row(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            Expanded(
                              child: Stack(
                                children: <Widget>[
                                  AspectRatio(
                                    aspectRatio: 1.2,
                                    child: Padding(
                                      padding: const EdgeInsets.only(
                                        right: 0,
                                        left: 0,
                                        top: 0,
                                        bottom: 0,
                                      ),
                                      child: LineChart(
                                        showAvg ? avgData() : mainData(),
                                      ),
                                    ),
                                  ),
                                ],
                              ),
                            ),
                            const SizedBox(
                              width: 10,
                            ),
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              SizedBox(height: 10),
            ]),
      ),
    );
  }

  LineChartData avgData() {
    return LineChartData(
      lineTouchData: const LineTouchData(enabled: false),
      gridData: FlGridData(
        show: true,
        drawHorizontalLine: true,
        drawVerticalLine: true,
        verticalInterval: 1,
        horizontalInterval: 1,
        getDrawingVerticalLine: (value) {
          return const FlLine(
            color: Color(0xff37434d),
            strokeWidth: 1,
          );
        },
        getDrawingHorizontalLine: (value) {
          return const FlLine(
            color: Color(0xff37434d),
            strokeWidth: 1,
          );
        },
      ),
      titlesData: FlTitlesData(
        show: true,
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            reservedSize: 30,
            getTitlesWidget: bottomTitleWidgets,
            interval: 1,
          ),
        ),
        leftTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: false,
            getTitlesWidget: leftTitleWidgets,
            reservedSize: 20,
            interval: 1,
          ),
        ),
        topTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        rightTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
      ),
      borderData: FlBorderData(
        show: true,
        border: Border.all(color: const Color(0xff37434d)),
      ),
      minX: 0,
      maxX: 11,
      minY: 0,
      maxY: 6,
      lineBarsData: [
        LineChartBarData(
          spots: const [
            FlSpot(0, 3.44),
            FlSpot(2.6, 3.44),
            FlSpot(4.9, 3.44),
            FlSpot(6.8, 3.44),
            FlSpot(8, 3.44),
            FlSpot(9.5, 3.44),
            FlSpot(11, 3.44),
          ],
          isCurved: false,
          gradient: LinearGradient(
            colors: [
              ColorTween(begin: gradientColors[0], end: gradientColors[1])
                  .lerp(0.2)!,
              ColorTween(begin: gradientColors[0], end: gradientColors[1])
                  .lerp(0.2)!,
            ],
          ),
          barWidth: 5,
          isStrokeCapRound: true,
          dotData: const FlDotData(
            show: false,
          ),
          belowBarData: BarAreaData(
            show: true,
            gradient: LinearGradient(
              colors: [
                ColorTween(begin: gradientColors[0], end: gradientColors[1])
                    .lerp(0.2)!
                    .withOpacity(0.1),
                ColorTween(begin: gradientColors[0], end: gradientColors[1])
                    .lerp(0.2)!
                    .withOpacity(0.1),
              ],
            ),
          ),
        ),
      ],
    );
  }

  LineChartData mainData() {
    return LineChartData(
      gridData: FlGridData(
        show: true,
        drawVerticalLine: true,
        drawHorizontalLine: true,
        horizontalInterval: 1,
        verticalInterval: 1,
        getDrawingHorizontalLine: (value) {
          return const FlLine(
            color: Color.fromARGB(21, 86, 86, 87),
            strokeWidth: 1,
          );
        },
        getDrawingVerticalLine: (value) {
          return const FlLine(
            color: Color.fromARGB(31, 138, 139, 139),
            strokeWidth: 1,
          );
        },
      ),
      titlesData: FlTitlesData(
        show: true,
        rightTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        topTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            reservedSize: 30,
            interval: 1,
            getTitlesWidget: bottomTitleWidgets,
          ),
        ),
        leftTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            interval: 1,
            getTitlesWidget: leftTitleWidgets,
            reservedSize: 20,
          ),
        ),
      ),
      borderData: FlBorderData(
        show: false,
        border: Border.all(
          color: const Color(0xffd9e2ff),
        ),
      ),
      minX: 0,
      maxX: 11,
      minY: 0,
      maxY: 5,
      lineBarsData: [
        LineChartBarData(
          color: Color(0xffd9e2ff),
          spots: const [
            FlSpot(0, 0),
            FlSpot(1, 4),
            FlSpot(3, 3.9),
            FlSpot(4, 5),
            FlSpot(6, 2),
            FlSpot(7, 1.5),
            FlSpot(8, 3),
            FlSpot(9, 5),
            FlSpot(10, 4),
            FlSpot(11, 3),
            FlSpot(11.5, 3),
          ],
          isCurved: false,
          // gradient: LinearGradient(
          //   colors: gradientColors,
          // ),
          barWidth: 5,
          isStrokeCapRound: false,
          dotData: FlDotData(
            getDotPainter: (spot, percent, barData, index) {
              if (index == activeIndex) {
                return FlDotCirclePainter(
                  radius: 5,
                  color: Color.fromARGB(125, 248, 42, 145),
                  strokeWidth: 0,
                  // strokeColor: Colors.black,
                );
              } else {
                return FlDotCirclePainter(
                  radius: 5,
                  color: Color.fromARGB(125, 248, 42, 145),

                  strokeWidth: 0,
                  // strokeColor: Colors.black,
                );
              }
            },
            show: true,
          ),
          belowBarData: BarAreaData(
            color: Color(0xffd9e2ff),
            show: true,
            // gradient: LinearGradient(
            //   colors:
            //       gradientColors.map((color) => color.withOpacity(1)).toList(),
            // ),
          ),
        ),
      ],
    );
  }

  Widget bottomTitleWidgets(double value, TitleMeta meta) {
    const style = TextStyle(
        // fontWeight: FontWeight.bold,
        fontSize: 10,
        color: Color.fromARGB(255, 30, 30, 30));
    Widget text;
    switch (value.toInt()) {
      case 2:
        text = const Text('0', style: style);
        break;
      case 5:
        text = const Text('1', style: style);
        break;
      case 8:
        text = const Text('2', style: style);
        break;
      case 11:
        text = const Text('3', style: style);
        break;
      case 14:
        text = const Text('4', style: style);
        break;
      case 17:
        text = const Text('5', style: style);
        break;
      default:
        text = const Text('', style: style);
        break;
    }

    return SideTitleWidget(
      axisSide: meta.axisSide,
      child: text,
    );
  }

  Widget leftTitleWidgets(double value, TitleMeta meta) {
    const style = TextStyle(
        // fontWeight: FontWeight.bol
        fontSize: 10,
        color: Color.fromARGB(255, 37, 36, 36));
    String text;
    switch (value.toInt()) {
      case 1:
        text = '600';
        break;
      case 3:
        text = '700';
        break;
      case 5:
        text = '800';
        break;
      case 7:
        text = '900';
      default:
        return Container();
    }

    return Text(text, style: style, textAlign: TextAlign.left);
  }
}
