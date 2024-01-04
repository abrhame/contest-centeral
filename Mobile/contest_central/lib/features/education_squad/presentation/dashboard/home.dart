import 'package:contest_central/core/utils/colors.dart';
import 'package:contest_central/features/education_squad/presentation/dashboard/card.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:toggle_switch/toggle_switch.dart';

import '../contest_list/contest_list.dart';
import '../profile/profile.dart';
import '../side_nav/drawer.dart';
import 'contestant_status.dart';
import 'top_contestants.dart';
import 'top_groups.dart';

class ESquadDashBoard extends StatefulWidget {
  const ESquadDashBoard({Key? key}) : super(key: key);

  @override
  _ESquadDashBoardState createState() => _ESquadDashBoardState();
}

class _ESquadDashBoardState extends State<ESquadDashBoard> {
  int touchedIndex = 0;
  List<Color> gradientColors = [
    AppColors.contentColorCyan,
    AppColors.contentColorBlue,
  ];
  int activeIndex = 0;
  bool showAvg = false;
  @override
  Widget build(BuildContext context) {
    SystemChrome.setSystemUIOverlayStyle(const SystemUiOverlayStyle(
        statusBarColor: Colors.transparent,
        statusBarIconBrightness: Brightness.dark));
    return Scaffold(
        backgroundColor: const Color(0xffF6f6f9),
        appBar: AppBar(
          backgroundColor: const Color(0xffF8FAFF),
          title: const SizedBox(
            width: 130,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(
                  Icons.dashboard,
                  size: 20,
                  color: Color.fromARGB(255, 87, 88, 91),
                ),
                Text(
                  "Dashboard",
                  style: TextStyle(
                      fontSize: 20, color: Color.fromARGB(255, 107, 114, 128)),
                )
              ],
            ),
          ),
          actions: [
            const Icon(
              Icons.notifications_outlined,
              color: Color.fromARGB(255, 120, 116, 134),
            ),
            const SizedBox(
              width: 7,
            ),
            GestureDetector(
              onTap: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => ProfilePolygonRoute(),
                  ),
                );
              },
              child: const CircleAvatar(
                radius: 15.0,
                backgroundImage: NetworkImage(
                    'https://th.bing.com/th/id/R.0f36a9b7563d5a0787b5661ce63f3ee8?rik=cJxNXWv6Gt5s8g&riu=http%3a%2f%2fadvantagebodylanguage.com%2fwp-content%2fuploads%2f2015%2f12%2fgewoman.jpg&ehk=nR1PFEO%2fHz1YZ3XLQsKWjtU3Ga%2boY%2f4NzLcCMXB3uYU%3d&risl=&pid=ImgRaw&r=0'),
              ),
            ),
            //  SizedBox(width:2,),

            const SizedBox(
              width: 20,
            )
          ],
        ),
        body: ListView(scrollDirection: Axis.vertical, children: [
          Container(
            height: 380,
            child: GridView.count(
              padding: const EdgeInsets.all(10),
              physics: const NeverScrollableScrollPhysics(),
              crossAxisCount: 2,
              crossAxisSpacing: 2,
              mainAxisSpacing: 2,
              children: [
                //CardWidget( BuildContext context, IconData icon, String title, String value, , Color color)
                GestureDetector(
                  onTap: () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => const ContestList(),
                      ),
                    );
                  },
                  child: CardWidget(context, Icons.bar_chart, "Total Contest",
                      "224", const Color(0xffe9edfa), const Color(0xff264eca)),
                ),
                CardWidget(context, Icons.group, "Total Groups", "5",
                    const Color(0xffe9f7ef), const Color(0xff26af61)),

                CardWidget(context, Icons.groups, "Total Members", "5",
                    const Color(0xfffef7e9), const Color(0xfff6b612)),
                CardWidget(context, Icons.alarm, "Total Hours", "1005",
                    const Color(0xfffde8e8), const Color(0xfffa4a49)),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(left: 10, right: 10),
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white,

                borderRadius: BorderRadius.circular(
                    8.0), // Set your desired border radius
                boxShadow: const [
                  BoxShadow(
                    color: Color.fromRGBO(149, 157, 165, 0.2), // Shadow color
                    offset: Offset(0, 8), // Offset in the x, y direction
                    blurRadius: 24.0, // Blur radius
                  ),
                ],
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  const SizedBox(height: 10),
                  Padding(
                    padding: const EdgeInsets.only(left: 8.0),
                    child: Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        ToggleSwitch(
                          minWidth: 60.0,
                          minHeight: 35.0,
                          fontSize: 13.0,
                          initialLabelIndex: 1,
                          borderWidth: 1,
                          borderColor: const [
                            Color.fromARGB(200, 194, 190, 190)
                          ],
                          dividerMargin: 1,
                          dividerColor:
                              const Color.fromARGB(236, 112, 108, 108),
                          activeBgColor: const [
                            Color.fromARGB(255, 177, 193, 225)
                          ],
                          activeFgColor: const Color.fromARGB(255, 23, 22, 22),
                          inactiveBgColor: Colors.white,
                          inactiveFgColor:
                              const Color.fromARGB(255, 97, 95, 95),
                          totalSwitches: 4,
                          labels: const ['Week', 'Months', 'Quarter', 'Year'],
                          onToggle: (index) {
                            print('switched to: $index');
                          },
                        ),
                        const SizedBox(
                          width: 10,
                        ),
                        SizedBox(
                          height: 37,
                          child: Container(
                            decoration: BoxDecoration(
                              color: Colors.white,
                              borderRadius: BorderRadius.circular(6.0),
                              border: Border.all(
                                  color:
                                      const Color.fromARGB(255, 212, 212, 212)),
                            ),
                            child: GestureDetector(
                              onTap: () {
                                // Navigator.pushReplacement(
                                //   context,
                                //   MaterialPageRoute(
                                //     builder: (context) => AddContest(),
                                //   ),
                                // );
                              },
                              child: const Padding(
                                padding: EdgeInsets.all(8.0),
                                child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Text("All ",
                                        style: TextStyle(color: Colors.grey)),
                                    Icon(Icons.keyboard_arrow_down,
                                        color: Colors.grey),
                                  ],
                                ),
                              ),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.only(left: 10.0, top: 0, bottom: 0),
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
          ),
          Container(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                TopGroups(),
                TopContestants(),
                ScrollableTableWithButton(),
              ],
            ),
          )
        ]),
        drawer: const EndDrawers());
  }

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
          barWidth: 5,
          isStrokeCapRound: true,
          dotData: const FlDotData(
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

  Widget bottomTitleWidgets(double value, TitleMeta meta) {
    const style = TextStyle(
        // fontWeight: FontWeight.bold,
        fontSize: 10,
        color: Color.fromARGB(255, 30, 30, 30));
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
      case 11:
        text = const Text('DEC', style: style);
        break;
      case 14:
        text = const Text('MAR', style: style);
        break;
      case 17:
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
      default:
        return Container();
    }

    return Text(text, style: style, textAlign: TextAlign.left);
  }
}
