// ignore_for_file: use_build_context_synchronously

import 'package:contest_central/features/education_squad/data/datasource/remote_data_source.dart';
import 'package:contest_central/features/education_squad/presentation/dashboard/card.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:toggle_switch/toggle_switch.dart';

import '../contest_list/contest_list.dart';
import '../profile/profile.dart';
import '../side_nav/drawer.dart';
import 'chart_info/chart_info.dart';
import 'contestant_status.dart';
import 'top_contestants.dart';
import 'top_groups.dart';

class ESquadDashBoard extends StatefulWidget {
  const ESquadDashBoard({Key? key}) : super(key: key);

  @override
  _ESquadDashBoardState createState() => _ESquadDashBoardState();
}

class _ESquadDashBoardState extends State<ESquadDashBoard> {
  Map<dynamic, dynamic> dashboardData = {};
  List<Map<dynamic, dynamic>> getRankedGroupsData = [];
  List<Map<dynamic, dynamic>> getContestsByFilterData = [];

  void fetchDashboardData() async {
    try {
      final dashboardApiDataSource = EducationSquadApiDataSource(
          baseUrl: 'https://a2sv-contest-central-api.onrender.com');
      final data = await dashboardApiDataSource.overAllStatus({});
      // print("==========> Dashboard Data : $data");
      setState(() {
        dashboardData = data;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Error: $e'),
          backgroundColor: Colors.red,
        ),
      );
    }
  }

  void fetchTopGroupData() async {
    try {
      final getRankedGroupsSource = EducationSquadApiDataSource(
          baseUrl: 'https://a2sv-contest-central-api.onrender.com');
      final data = await getRankedGroupsSource.getRankedGroups();
      // print("==========> RankedGroups Data : $data");
      setState(() {
        getRankedGroupsData = data;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Getting Rank Error: $e'),
          backgroundColor: Colors.red,
        ),
      );
    }
  }

  void getContestsByFilter() async {
    try {
      final getContestsByFilterSource = EducationSquadApiDataSource(
          baseUrl: 'https://a2sv-contest-central-api.onrender.com');
      final data = await getContestsByFilterSource.getContestsByFilter();
      // print("==========> getContestsByFilter Data : $data");
      setState(() {
        getContestsByFilterData = data;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Getting ContestsByFilter Error: $e'),
          backgroundColor: Colors.red,
        ),
      );
    }
  }

  Future<void> _refreshData() async {
    await Future.delayed(const Duration(seconds: 1));
    fetchDashboardData();
    fetchTopGroupData();
    getContestsByFilter();
  }

  @override
  void initState() {
    super.initState();
    fetchDashboardData();
    fetchTopGroupData();
    getContestsByFilter();
  }

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
                backgroundImage: AssetImage('assets/images/no_profile.png'),
              ),
            ),
            //  SizedBox(width:2,),

            const SizedBox(
              width: 20,
            )
          ],
        ),
        body: RefreshIndicator(
          onRefresh: _refreshData,
          child: ListView(scrollDirection: Axis.vertical, children: [
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
                    child: CardWidget(
                        context,
                        Icons.bar_chart,
                        "Total Contest",
                        dashboardData['totalContest'].toString() ?? "0",
                        const Color(0xffe9edfa),
                        const Color(0xff264eca)),
                  ),
                  CardWidget(
                      context,
                      Icons.group,
                      "Total Groups",
                      dashboardData['totalGroup'].toString() ?? "0",
                      const Color(0xffe9f7ef),
                      const Color(0xff26af61)),

                  CardWidget(
                      context,
                      Icons.groups,
                      "Total Members",
                      dashboardData['totalMembers'].toString() ?? "0",
                      const Color(0xfffef7e9),
                      const Color(0xfff6b612)),
                  CardWidget(
                      context,
                      Icons.alarm,
                      "Total Hours",

                      // (dashboardData['totalMinutes'] / 60).toStringAsFixed(2) ??
                      //     "0",
                      // check if it is null
                      dashboardData['totalMinutes'] != null
                          ? (dashboardData['totalMinutes'] / 60)
                              .toStringAsFixed(2)
                          : "0",
                      const Color(0xfffde8e8),
                      const Color(0xfffa4a49)),
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
                            activeFgColor:
                                const Color.fromARGB(255, 23, 22, 22),
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
                                    color: const Color.fromARGB(
                                        255, 212, 212, 212)),
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
                  TopGroups(getRankedGroupsData: getRankedGroupsData),
                  TopContestants(),
                  ScrollableTableWithButton(
                      getContestsByFilterData: getContestsByFilterData),
                ],
              ),
            )
          ]),
        ),
        drawer: const EndDrawers());
  }
}
