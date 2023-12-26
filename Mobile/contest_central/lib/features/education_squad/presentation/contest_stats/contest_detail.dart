import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter/services.dart';

import '../../../../../../../../core/utils/circle_image.dart';
import '../../../../../../../../core/utils/img.dart';
import '../../../../../../../../core/utils/my_colors.dart';
import '../../../../../../../../core/utils/my_text.dart';
import '../contest_add/add_contest.dart';
import 'floating_action.dart';
import 'pi_chart_widget.dart';

class ContestDetail extends StatefulWidget {
  const ContestDetail({super.key});

  @override
  _ContestDetailState createState() => _ContestDetailState();
}

class _ContestDetailState extends State<ContestDetail> {
  late int showingTooltip;

  @override
  void initState() {
    showingTooltip = -1;
    super.initState();
  }

  BarChartGroupData generateGroupData(int x, int y) {
    return BarChartGroupData(
      x: x,
      showingTooltipIndicators: showingTooltip == x ? [0] : [],
      barRods: [
        BarChartRodData(
          fromY: y.toDouble(),
          toY: 0,
          gradient: const LinearGradient(
            begin: Alignment.bottomCenter,
            end: Alignment.topCenter,
            colors: [
              Color.fromARGB(75, 38, 79, 202),
              Color(0xFF264ECA),
            ],
          ),
          // borderSide: const BorderSide(
          //     width: 6, color: Color.fromARGB(20, 38, 79, 202)),
        )
        // borderSide: const BorderSide(width: 6)),
      ],
    );
  }

  bool _showFab = true;
  @override
  Widget build(BuildContext context) {
    SystemChrome.setSystemUIOverlayStyle(const SystemUiOverlayStyle(
        statusBarColor: Colors.transparent,
        statusBarIconBrightness: Brightness.dark));
    const duration = Duration(milliseconds: 300);
    return Scaffold(
        backgroundColor: const Color(0xffF8FAFF),
        body: NotificationListener<UserScrollNotification>(
          onNotification: (notification) {
            final ScrollDirection direction = notification.direction;
            setState(() {
              if (direction == ScrollDirection.reverse) {
                _showFab = false;
              } else if (direction == ScrollDirection.forward) {
                _showFab = true;
              }
            });
            return true;
          },
          child: CustomScrollView(
            slivers: <Widget>[
              SliverAppBar(
                systemOverlayStyle: const SystemUiOverlayStyle(
                  statusBarBrightness: Brightness.light,
                ),
                backgroundColor: const Color(0xffF8FAFF),
                floating: true,
                pinned: false,
                snap: false,
                title: Row(
                  children: <Widget>[
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Row(
                          children: [
                            SizedBox(
                                width: 24,
                                height: 24,
                                child: Image.asset('assets/images/outline.png',
                                    width: 24, height: 24)),

                            // text
                            Container(width: 5),
                            Text(
                              "/ Contest",
                              style: MyText.body2(context)?.copyWith(
                                color: MyColors.grey_60,
                                fontWeight: FontWeight.w500,
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ],
                ),
                leading: Row(
                  children: [
                    const SizedBox(
                      width: 15,
                    ),
                    // ios arrow back icon button,
                    GestureDetector(
                      onTap: () {
                        // go back
                        Navigator.pop(context);
                      },
                      child:
                          Icon(Icons.arrow_back_ios, color: MyColors.grey_60),
                    )
                  ],
                ),
                actions: <Widget>[
                  CircleImage(
                    imageProvider: AssetImage(Img.get('image 1.png')),
                    size: 40,
                  ),
                  Container(width: 10),
                  const Icon(Icons.keyboard_arrow_down,
                      color: MyColors.grey_60),
                ],
              ),
              SliverList(
                delegate: SliverChildBuilderDelegate(
                    (BuildContext context, int index) {
                  return Column(
                    children: [
                      const SizedBox(height: 16.0),
                      Center(
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(6.0),
                                border: Border.all(
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
                              ),
                              child: GestureDetector(
                                onTap: () {
                                  Navigator.pushReplacement(
                                    context,
                                    MaterialPageRoute(
                                      builder: (context) => AddContest(),
                                    ),
                                  );
                                },
                                child: const Padding(
                                  padding: EdgeInsets.all(8.0),
                                  child: Row(
                                    mainAxisAlignment:
                                        MainAxisAlignment.spaceBetween,
                                    children: [
                                      Text("Ethiopia ",
                                          style: TextStyle(color: Colors.grey)),
                                      Icon(Icons.keyboard_arrow_down,
                                          color: Colors.grey),
                                    ],
                                  ),
                                ),
                              ),
                            ),
                            const SizedBox(width: 16.0),
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(6.0),
                                border: Border.all(
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
                              ),
                              child: const Padding(
                                padding: EdgeInsets.all(8.0),
                                child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Text("AASTU ",
                                        style: TextStyle(color: Colors.grey)),
                                    Icon(Icons.keyboard_arrow_down,
                                        color: Colors.grey),
                                  ],
                                ),
                              ),
                            ),
                            const SizedBox(width: 16.0),
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(6.0),
                                border: Border.all(
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
                              ),
                              child: const Padding(
                                padding: EdgeInsets.all(8.0),
                                child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Text("G46 ",
                                        style: TextStyle(color: Colors.grey)),
                                    Icon(Icons.keyboard_arrow_down,
                                        color: Colors.grey),
                                  ],
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),

                      // Bold text title  "problems status"
                      const SizedBox(height: 16.0),
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 16.0),
                        child: Row(
                          children: [
                            Text(
                              "Problems Status",
                              style: MyText.body2(context)?.copyWith(
                                fontSize: 20,
                                color: MyColors.grey_90,
                                fontWeight: FontWeight.w500,
                              ),
                            ),
                          ],
                        ),
                      ),

                      const SizedBox(height: 16.0),
                      // Chart
                      Padding(
                        padding: const EdgeInsets.only(left: 10, right: 10),
                        child: Container(
                          decoration: BoxDecoration(
                            color: Colors.white,

                            borderRadius: BorderRadius.circular(
                                8.0), // Set your desired border radius
                            boxShadow: const [
                              BoxShadow(
                                color: Color.fromRGBO(
                                    149, 157, 165, 0.2), // Shadow color
                                offset: Offset(
                                    0, 8), // Offset in the x, y direction
                                blurRadius: 24.0, // Blur radius
                              ),
                            ],
                          ),
                          child: Center(
                            child: Padding(
                              padding: const EdgeInsets.only(
                                  top: 50, bottom: 30, left: 3, right: 3),
                              child: AspectRatio(
                                aspectRatio: 1.3,
                                child: BarChart(
                                  BarChartData(
                                    // hide y axis grid lines
                                    gridData: FlGridData(
                                      drawVerticalLine: false,
                                      getDrawingHorizontalLine: (value) {
                                        return const FlLine(
                                          color: Color.fromARGB(
                                              255, 106, 112, 116),
                                          strokeWidth: 0.1,
                                        );
                                      },
                                    ),

                                    titlesData: const FlTitlesData(
                                      show: true,
                                      rightTitles: AxisTitles(
                                        drawBelowEverything: false,
                                      ),
                                      topTitles: AxisTitles(
                                        drawBelowEverything: false,
                                      ),
                                    ),

                                    borderData: FlBorderData(
                                      show: false,
                                    ),
                                    barGroups: [
                                      generateGroupData(1, 10),
                                      generateGroupData(2, 12),
                                      generateGroupData(3, 4),
                                      generateGroupData(4, 11),
                                      generateGroupData(4, 11),
                                    ],
                                    barTouchData: BarTouchData(
                                        enabled: true,
                                        handleBuiltInTouches: false,
                                        touchCallback: (event, response) {
                                          if (response != null &&
                                              response.spot != null &&
                                              event is FlTapUpEvent) {
                                            setState(() {
                                              final x = response
                                                  .spot!.touchedBarGroup.x;
                                              final isShowing =
                                                  showingTooltip == x;
                                              if (isShowing) {
                                                showingTooltip = -1;
                                              } else {
                                                showingTooltip = x;
                                              }
                                            });
                                          }
                                        },
                                        mouseCursorResolver: (event, response) {
                                          return response == null ||
                                                  response.spot == null
                                              ? MouseCursor.defer
                                              : SystemMouseCursors.click;
                                        }),
                                  ),
                                ),
                              ),
                            ),
                          ),
                        ),
                      ),

                      // Bold text title  "problems status"
                      const SizedBox(height: 16.0),
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 16.0),
                        child: Row(
                          children: [
                            Text(
                              "Avarage Conversion Rate",
                              style: MyText.body2(context)?.copyWith(
                                fontSize: 20,
                                color: MyColors.grey_90,
                                fontWeight: FontWeight.w500,
                              ),
                            ),
                          ],
                        ),
                      ),

                      const SizedBox(height: 16.0),

                      // pi chart
                      Padding(
                          padding: const EdgeInsets.only(left: 10, right: 10),
                          child: Container(
                              decoration: BoxDecoration(
                                color: Colors.white,

                                borderRadius: BorderRadius.circular(
                                    8.0), // Set your desired border radius
                                boxShadow: const [
                                  BoxShadow(
                                    color: Color.fromRGBO(
                                        149, 157, 165, 0.2), // Shadow color
                                    offset: Offset(
                                        0, 8), // Offset in the x, y direction
                                    blurRadius: 24.0, // Blur radius
                                  ),
                                ],
                              ),
                              child: Center(
                                  child: Padding(
                                padding: const EdgeInsets.only(
                                    top: 20, bottom: 15, left: 3, right: 3),
                                child: AspectRatio(
                                  aspectRatio: 1.3,
                                  child: AspectRatio(
                                    aspectRatio: 1,
                                    child: PieChart(
                                      PieChartData(
                                        pieTouchData: PieTouchData(
                                          touchCallback: (FlTouchEvent event,
                                              pieTouchResponse) {
                                            setState(() {
                                              if (!event
                                                      .isInterestedForInteractions ||
                                                  pieTouchResponse == null ||
                                                  pieTouchResponse
                                                          .touchedSection ==
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
                                        centerSpaceRadius: 0,
                                        sections: showingSections(),
                                      ),
                                    ),
                                  ),
                                ),
                              )))),

                      // delete filter and search
                      const SizedBox(height: 16.0),
                      Center(
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(6.0),
                                border: Border.all(
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
                              ),
                              child: const Padding(
                                padding: EdgeInsets.all(8.0),
                                child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Icon(Icons.delete, color: Colors.grey),
                                    Text("Delete ",
                                        style: TextStyle(color: Colors.grey)),
                                  ],
                                ),
                              ),
                            ),
                            const SizedBox(width: 16.0),
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(6.0),
                                border: Border.all(
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
                              ),
                              child: const Padding(
                                padding: EdgeInsets.all(8.0),
                                child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Icon(Icons.tune, color: Colors.grey),
                                    Text("Filter ",
                                        style: TextStyle(color: Colors.grey)),
                                  ],
                                ),
                              ),
                            ),
                            const SizedBox(width: 16.0),
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(6.0),
                                border: Border.all(
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
                              ),
                              child: const Padding(
                                padding: EdgeInsets.only(
                                  left: 8,
                                ),
                                child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Icon(Icons.search,
                                        color: Colors.grey, size: 20),
                                    // search box with border radius and "Search placeholder"

                                    SizedBox(
                                      width: 100,
                                      child: TextField(
                                        decoration: InputDecoration(
                                          border: InputBorder.none,
                                          hintText: ' Search',
                                          hintStyle: TextStyle(
                                            fontSize: 14,
                                            color: Colors.grey,
                                          ),
                                        ),
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),

                      const SizedBox(height: 16.0),
                    ],
                  );
                }, childCount: 1),
              )
            ],
          ),
        ),
        floatingActionButton: AnimatedSlide(
            duration: duration,
            offset: _showFab ? Offset.zero : const Offset(0, 2),
            child: AnimatedOpacity(
                duration: duration,
                opacity: _showFab ? 1 : 0,
                child: buildSpeedDial(context))));
  }
}
