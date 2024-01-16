import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';

import '../../../../../core/utils/colors.dart';

int touchedIndex = 0;
List<Color> gradientColors = [
  Color.fromARGB(215, 138, 147, 154),
  Color.fromARGB(0, 138, 147, 154)
];
int activeIndex = 0;
bool showAvg = false;

LineChartData avgData() {
  return LineChartData(
    lineTouchData: const LineTouchData(enabled: false),
    gridData: FlGridData(
      show: true,
      drawHorizontalLine: true,
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
          showTitles: true,
          getTitlesWidget: leftTitleWidgets,
          reservedSize: 42,
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
        isCurved: true,
        gradient: LinearGradient(
          colors: [const Color(0xff37434d)],
        ),
        barWidth: 5,
        isStrokeCapRound: true,
        dotData: const FlDotData(
          show: false,
        ),
        belowBarData: BarAreaData(
          show: true,
          gradient: LinearGradient(
            colors: [const Color(0xff37434d)],
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
      horizontalInterval: 1,
      verticalInterval: 1,
      getDrawingHorizontalLine: (value) {
        return const FlLine(
          color: AppColors.mainGridLineColor,
          strokeWidth: 1,
        );
      },
      getDrawingVerticalLine: (value) {
        return const FlLine(
          color: Color.fromARGB(26, 95, 95, 95),
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
          reservedSize: 15,
        ),
      ),
    ),
    borderData: FlBorderData(
      show: false,
      border: Border.all(color: const Color.fromARGB(255, 255, 255, 255)),
    ),
    minX: 0,
    maxX: 11,
    minY: 0,
    maxY: 5,
    lineBarsData: [
      LineChartBarData(
        spots: const [
          FlSpot(0, 3),
          FlSpot(2.6, 2),
          FlSpot(4.9, 5),
          FlSpot(6.8, 3.1),
          FlSpot(8, 4),
          FlSpot(9.5, 3),
          FlSpot(11, 4),
        ],
        isCurved: true,
        gradient: LinearGradient(
          colors: gradientColors,
        ),
        barWidth: 2,
        isStrokeCapRound: true,
        dotData: const FlDotData(
          show: false,
        ),
        belowBarData: BarAreaData(
          color: Color.fromARGB(171, 217, 226, 255),

          show: true,
          // gradient: LinearGradient(
          //   colors: gradientColors
          //       .map((color) => color.withOpacity(0.3))
          //       .toList(),
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
    case 0:
      text = const Text('MAR', style: style);
      break;
    case 2:
      text = const Text('JUN', style: style);
      break;
    case 5:
      text = const Text('SEP', style: style);
      break;
    case 7:
      text = const Text('DEC', style: style);
      break;
    case 9:
      text = const Text('MAR', style: style);
      break;
    case 12:
      text = const Text('JUN', style: style);
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
      text = '3';
      break;
    case 3:
      text = '4';
      break;
    case 5:
      text = '5';
      break;
    case 7:
      text = '7';
    case 10:
      text = '10';
    default:
      return Container();
  }

  return Text(text, style: style, textAlign: TextAlign.left);
}
