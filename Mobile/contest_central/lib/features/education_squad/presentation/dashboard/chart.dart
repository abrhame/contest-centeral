import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';
import 'standing.dart';

class ContestStatistics extends StatefulWidget {
  const ContestStatistics({super.key});

  @override
  State<ContestStatistics> createState() => _ContestStatisticsState();
}

class _ContestStatisticsState extends State<ContestStatistics> {
  int touchedIndex = 0;
  List<Color> gradientColors = [
    AppColors.contentColorCyan,
    AppColors.contentColorBlue,
  ];
  int activeIndex = 0;
  bool showAvg = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          backgroundColor: AppColors.gridLinesColor,
          title: const Text("Weekly Contest Statistics"),
          leading: IconButton(
            icon: const Icon(Icons.arrow_back_ios),
            onPressed: () {
              Navigator.pop(context);
            },
          ),
        ),
        body: SingleChildScrollView(
            child:
                Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
          const SizedBox(height: 10),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              decoration: BoxDecoration(
                color: AppColors.itemsBackground,
                borderRadius: BorderRadius.circular(16),
                boxShadow: const [
                  BoxShadow(
                    color: AppColors.borderColor,
                    blurRadius: 10,
                    offset: Offset(0, 5),
                  ),
                ],
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const SizedBox(height: 10),
                  // Attendace Statistics
                  const Padding(
                    padding: EdgeInsets.only(left: 8.0),
                    child: Text(
                      'Attendace Statistics',
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                        color: AppColors.mainTextColor1,
                      ),
                    ),
                  ),
                  // Contest Performance
                  Padding(
                    padding:
                        const EdgeInsets.only(left: 25.0, top: 15, bottom: 25),
                    child: AspectRatio(
                      aspectRatio: 2,
                      child: Row(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          Expanded(
                            child: AspectRatio(
                              aspectRatio: 0.6,
                              child: PieChart(
                                PieChartData(
                                  pieTouchData: PieTouchData(
                                    touchCallback:
                                        (FlTouchEvent event, pieTouchResponse) {
                                      setState(() {
                                        if (!event
                                                .isInterestedForInteractions ||
                                            pieTouchResponse == null ||
                                            pieTouchResponse.touchedSection ==
                                                null) {
                                          touchedIndex = -1;
                                          return;
                                        }
                                        touchedIndex = pieTouchResponse
                                            .touchedSection!
                                            .touchedSectionIndex;
                                      });
                                    },
                                  ),
                                  borderData: FlBorderData(
                                    show: false,
                                  ),
                                  sectionsSpace: 0,
                                  centerSpaceRadius: 40,
                                  sections: showingSections(),
                                ),
                              ),
                            ),
                          ),
                          const Column(
                            mainAxisAlignment: MainAxisAlignment.end,
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: <Widget>[
                              Indicator(
                                color: AppColors.contentColorBlue,
                                text: 'Group 41',
                                isSquare: true,
                                textColor: AppColors.mainTextColor1,
                              ),
                              SizedBox(
                                height: 4,
                              ),
                              Indicator(
                                color: AppColors.contentColorYellow,
                                text: 'Group 42',
                                isSquare: true,
                                textColor: AppColors.mainTextColor1,
                              ),
                              SizedBox(
                                height: 4,
                              ),
                              Indicator(
                                color: AppColors.contentColorPurple,
                                text: 'Group 43',
                                isSquare: true,
                                textColor: AppColors.mainTextColor1,
                              ),
                              SizedBox(
                                height: 4,
                              ),
                              Indicator(
                                color: AppColors.contentColorGreen,
                                text: 'Group 44',
                                isSquare: true,
                                textColor: AppColors.mainTextColor1,
                              ),
                              SizedBox(
                                height: 18,
                              ),
                            ],
                          ),
                          const SizedBox(
                            width: 28,
                          ),
                        ],
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
          const SizedBox(height: 10),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              decoration: BoxDecoration(
                color: Color.fromARGB(255, 20, 42, 103),
                borderRadius: BorderRadius.circular(16),
                boxShadow: const [
                  BoxShadow(
                    color: AppColors.borderColor,
                    blurRadius: 10,
                    offset: Offset(0, 5),
                  ),
                ],
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const SizedBox(height: 10),
                  Padding(
                    padding: const EdgeInsets.only(left: 8.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        const Padding(
                          padding: EdgeInsets.all(8.0),
                          child: Text(
                            'Contest',
                            style: TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 18,
                              color: AppColors.mainTextColor1,
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 40,
                          child: ListView(
                            scrollDirection: Axis.horizontal,
                            children: [
                              for (int i = 51; i <= 60; i++)
                                Padding(
                                  padding: const EdgeInsets.symmetric(
                                      horizontal: 8.0),
                                  child: Text(
                                    'G$i',
                                    style: TextStyle(
                                      fontSize: 18,
                                      fontWeight: i == activeIndex
                                          ? FontWeight.bold
                                          : FontWeight.normal,
                                      color: i == activeIndex
                                          ? Colors.blue
                                          : Colors.white,
                                      decoration: i == activeIndex
                                          ? TextDecoration.underline
                                          : TextDecoration.none,
                                    ),
                                  ),
                                ),
                            ],
                          ),
                        )
                      ],
                    ),
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.only(left: 25.0, top: 15, bottom: 25),
                    child: AspectRatio(
                      aspectRatio: 2,
                      child: Row(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          Expanded(
                              child: Stack(
                            children: <Widget>[
                              AspectRatio(
                                aspectRatio: 1.90,
                                child: Padding(
                                  padding: const EdgeInsets.only(
                                    right: 0,
                                    left: 12,
                                    top: 24,
                                    bottom: 12,
                                  ),
                                  child: LineChart(
                                    showAvg ? avgData() : mainData(),
                                  ),
                                ),
                              ),
                              SizedBox(
                                width: 60,
                                height: 34,
                                child: TextButton(
                                  onPressed: () {
                                    setState(() {
                                      showAvg = !showAvg;
                                    });
                                  },
                                  child: Text(
                                    'Avg',
                                    style: TextStyle(
                                      fontSize: 12,
                                      color: showAvg
                                          ? Colors.white.withOpacity(0.5)
                                          : Colors.white,
                                    ),
                                  ),
                                ),
                              ),
                            ],
                          )),
                          const SizedBox(
                            width: 28,
                          ),
                        ],
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
          // Coontest Standing
          SizedBox(
            child: ContestStanding(),
          ),
        ])));
  }

  Widget bottomTitleWidgets(double value, TitleMeta meta) {
    const style = TextStyle(
        fontWeight: FontWeight.bold, fontSize: 16, color: Colors.white);
    Widget text;
    switch (value.toInt()) {
      case 2:
        text = const Text('MAR', style: style);
        break;
      case 5:
        text = const Text('JUN', style: style);
        break;
      case 8:
        text = const Text('SEP', style: style);
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
        fontWeight: FontWeight.bold, fontSize: 15, color: Colors.white);
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
      default:
        return Container();
    }

    return Text(text, style: style, textAlign: TextAlign.left);
  }

  LineChartData mainData() {
    return LineChartData(
      gridData: FlGridData(
        show: true,
        drawVerticalLine: true,
        horizontalInterval: 1,
        verticalInterval: 1,
        getDrawingHorizontalLine: (value) {
          return FlLine(
            color: AppColors.mainGridLineColor,
            strokeWidth: 1,
          );
        },
        getDrawingVerticalLine: (value) {
          return FlLine(
            color: AppColors.mainGridLineColor,
            strokeWidth: 1,
          );
        },
      ),
      titlesData: FlTitlesData(
        show: true,
        rightTitles: AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        topTitles: AxisTitles(
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
            reservedSize: 42,
          ),
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
          barWidth: 5,
          isStrokeCapRound: true,
          dotData: FlDotData(
            show: false,
          ),
          belowBarData: BarAreaData(
            show: true,
            gradient: LinearGradient(
              colors: gradientColors
                  .map((color) => color.withOpacity(0.3))
                  .toList(),
            ),
          ),
        ),
      ],
    );
  }

  LineChartData avgData() {
    return LineChartData(
      lineTouchData: LineTouchData(enabled: false),
      gridData: FlGridData(
        show: true,
        drawHorizontalLine: true,
        verticalInterval: 1,
        horizontalInterval: 1,
        getDrawingVerticalLine: (value) {
          return FlLine(
            color: Color(0xff37434d),
            strokeWidth: 1,
          );
        },
        getDrawingHorizontalLine: (value) {
          return FlLine(
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
        topTitles: AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        rightTitles: AxisTitles(
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
            colors: [
              ColorTween(begin: gradientColors[0], end: gradientColors[1])
                  .lerp(0.2)!,
              ColorTween(begin: gradientColors[0], end: gradientColors[1])
                  .lerp(0.2)!,
            ],
          ),
          barWidth: 5,
          isStrokeCapRound: true,
          dotData: FlDotData(
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

  List<PieChartSectionData> showingSections() {
    return List.generate(4, (i) {
      final isTouched = i == touchedIndex;
      final fontSize = isTouched ? 25.0 : 16.0;
      final radius = isTouched ? 60.0 : 50.0;
      const shadows = [Shadow(color: Colors.black, blurRadius: 2)];
      switch (i) {
        case 0:
          return PieChartSectionData(
            color: AppColors.contentColorBlue,
            value: 40,
            title: '40%',
            radius: radius,
            titleStyle: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.bold,
              color: AppColors.mainTextColor1,
              shadows: shadows,
            ),
          );
        case 1:
          return PieChartSectionData(
            color: AppColors.contentColorYellow,
            value: 30,
            title: '30%',
            radius: radius,
            titleStyle: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.bold,
              color: AppColors.mainTextColor1,
              shadows: shadows,
            ),
          );
        case 2:
          return PieChartSectionData(
            color: AppColors.contentColorPurple,
            value: 15,
            title: '15%',
            radius: radius,
            titleStyle: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.bold,
              color: AppColors.mainTextColor1,
              shadows: shadows,
            ),
          );
        case 3:
          return PieChartSectionData(
            color: AppColors.contentColorGreen,
            value: 15,
            title: '15%',
            radius: radius,
            titleStyle: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.bold,
              color: AppColors.mainTextColor1,
              shadows: shadows,
            ),
          );
        default:
          throw Error();
      }
    });
  }
}

class Indicator extends StatelessWidget {
  const Indicator({
    super.key,
    required this.color,
    required this.text,
    required this.isSquare,
    this.size = 16,
    this.textColor,
  });
  final Color color;
  final String text;
  final bool isSquare;
  final double size;
  final Color? textColor;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: <Widget>[
        Container(
          width: size,
          height: size,
          decoration: BoxDecoration(
            shape: isSquare ? BoxShape.rectangle : BoxShape.circle,
            color: color,
          ),
        ),
        const SizedBox(
          width: 4,
        ),
        Text(
          text,
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.bold,
            color: textColor,
          ),
        )
      ],
    );
  }
}
