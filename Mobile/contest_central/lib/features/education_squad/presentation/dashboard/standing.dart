import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';
import 'user_list.dart';

class ContestStanding extends StatefulWidget {
  @override
  _ContestStandingState createState() => _ContestStandingState();
}

class _ContestStandingState extends State<ContestStanding>
    with SingleTickerProviderStateMixin {
  TabController? _tabController;

  @override
  void initState() {
    _tabController = TabController(length: 5, vsync: this);
    super.initState();
  }

  @override
  void dispose() {
    _tabController!.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        const SizedBox(height: 10),
        Container(
          child: const Text(
            "Contest Standing",
            style: TextStyle(
              fontSize: 20,
              fontWeight: FontWeight.bold,
              color: AppColors.itemsBackground,
            ),
          ),
        ),
        const SizedBox(height: 10),
        SizedBox(
          // Wrap the outer Container with Expanded
          child: Container(
            width: 400,
            height: 400,
            decoration: const BoxDecoration(
              color: AppColors.itemsBackground,
            ),
            child: Column(
              children: [
                TabBar(
                  indicatorColor: Colors.white,
                  indicatorSize: TabBarIndicatorSize.tab,
                  indicatorWeight: 4,
                  tabs: const [
                    Tab(
                        icon: Text("All",
                            style:
                                TextStyle(fontSize: 15, color: Colors.white))),
                    Tab(
                        icon: Text("G41",
                            style:
                                TextStyle(fontSize: 15, color: Colors.white))),
                    Tab(
                        icon: Text("G42",
                            style:
                                TextStyle(fontSize: 15, color: Colors.white))),
                    Tab(
                        icon: Text("G43",
                            style:
                                TextStyle(fontSize: 15, color: Colors.white))),
                    Tab(
                        icon: Text("G44",
                            style:
                                TextStyle(fontSize: 15, color: Colors.white))),
                  ],
                  controller: _tabController,
                ),
                const SizedBox(height: 10),
                Expanded(
                  // Wrap the TabBarView with Expanded
                  child: TabBarView(
                    controller: _tabController,
                    children: [
                      Container(
                        padding: const EdgeInsets.all(1.0),
                        child: Column(
                          children: [
                            buildUserStanding(1, 'Gemechis Elias', 'Group 41',
                                '5 out of 7 Solved'),
                            const Divider(
                              color: Color.fromRGBO(210, 210, 210, 0.47),
                              thickness: 0.5,
                            ),
                            buildUserStanding(
                                2, 'John Doe', 'Group 27', '4 out of 7 Solved'),
                            const Divider(
                              color: Color.fromRGBO(210, 210, 210, 0.47),
                              thickness: 0.5,
                            ),
                            // Add more user standings as needed
                          ],
                        ),
                      ),
                      const Align(
                          child: Text("No G41 Data",
                              style: TextStyle(
                                  fontSize: 20, color: Colors.white))),
                      const Align(
                          child: Text("No G42 Data",
                              style: TextStyle(
                                  fontSize: 20, color: Colors.white))),
                      const Align(
                          child: Text("No G43 Data",
                              style: TextStyle(
                                  fontSize: 20, color: Colors.white))),
                      const Align(
                          child: Text("No G44 Data",
                              style: TextStyle(
                                  fontSize: 20, color: Colors.white))),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ),
      ],
    );
  }
}
