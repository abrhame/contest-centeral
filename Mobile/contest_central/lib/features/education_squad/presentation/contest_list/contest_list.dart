import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:horizontal_data_table/horizontal_data_table.dart';

import '../contest_stats/contest_detail.dart';
import '../contest_stats/floating_action.dart';

class ContestList extends StatefulWidget {
  const ContestList({super.key});

  @override
  _ContestListState createState() => _ContestListState();
}

class _ContestListState extends State<ContestList> {
  late int showingTooltip;
  final TextEditingController _searchController = TextEditingController();
  late ScrollController verticalScrollController;
  // late ScrollController _horizontalScrollController;
  bool _showFab = true;

  @override
  void initState() {
    showingTooltip = -1;
    super.initState();

    verticalScrollController = ScrollController();
  }

  final int rowsCount = 50; // Number of rows in the table
  final int columnsCount = 5; // Number of columns in the table

  @override
  Widget build(BuildContext context) {
    SystemChrome.setSystemUIOverlayStyle(const SystemUiOverlayStyle(
        statusBarColor: Colors.transparent,
        statusBarIconBrightness: Brightness.dark));
    const duration = Duration(milliseconds: 300);

    return Scaffold(
        backgroundColor: Colors.grey[100],
        appBar: AppBar(
          backgroundColor:
              Colors.white, // Set the AppBar background to transparent
          elevation: 0,
          leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
            },
            icon: const Icon(
              Icons.arrow_back_ios,
              size: 24,
              color: Color.fromARGB(255, 120, 116, 134),
            ),
          ),
          title: const SizedBox(
            width: 130,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(
                  Icons.corporate_fare,
                  size: 20,
                  color: Color.fromARGB(255, 87, 88, 91),
                ),
                Text(
                  "/",
                  style: TextStyle(
                      fontSize: 20, color: Color.fromARGB(255, 209, 213, 219)),
                ),
                Text(
                  "Contests",
                  style: TextStyle(
                      fontSize: 20, color: Color.fromARGB(255, 107, 114, 128)),
                )
              ],
            ),
          ),
          actions: const [
            Icon(
              Icons.notifications_outlined,
              color: Color.fromARGB(255, 120, 116, 134),
            ),
            SizedBox(
              width: 7,
            ),
            CircleAvatar(
              radius: 15.0,
              backgroundImage: NetworkImage(
                  'https://th.bing.com/th/id/R.0f36a9b7563d5a0787b5661ce63f3ee8?rik=cJxNXWv6Gt5s8g&riu=http%3a%2f%2fadvantagebodylanguage.com%2fwp-content%2fuploads%2f2015%2f12%2fgewoman.jpg&ehk=nR1PFEO%2fHz1YZ3XLQsKWjtU3Ga%2boY%2f4NzLcCMXB3uYU%3d&risl=&pid=ImgRaw&r=0'),
            ),
            //  SizedBox(width:2,),
            Icon(
              Icons.expand_more,
              color: Color.fromARGB(255, 41, 45, 50),
            ),
            SizedBox(
              width: 20,
            )
          ],
        ),
        body: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 10.0),
            child: Column(
              children: [
                const SizedBox(
                  height: 16,
                ),
                Center(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Container(
                        decoration: BoxDecoration(
                          color: Colors.white,
                          borderRadius: BorderRadius.circular(10.0),
                          border: Border.all(
                              color: const Color.fromARGB(255, 212, 212, 212)),
                        ),
                        child: const Padding(
                          padding: EdgeInsets.all(5.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Icon(Icons.text_rotate_vertical,
                                  color: Colors.grey),
                              Text(" Sort ",
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
                              color: const Color.fromARGB(255, 212, 212, 212)),
                        ),
                        child: const Padding(
                          padding: EdgeInsets.all(5.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Icon(Icons.tune, color: Colors.grey),
                              Text("Filter ",
                                  style: TextStyle(color: Colors.grey)),
                            ],
                          ),
                        ),
                      ),
                      const SizedBox(width: 16.0),
                      Expanded(
                        child: SizedBox(
                          height: 37,
                          child: TextFormField(
                            controller: _searchController,
                            decoration: const InputDecoration(
                              hintText: 'Search ',
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(
                                  color: Color(0xffDFE2E6),
                                ),
                                borderRadius: BorderRadius.all(
                                  Radius.circular(16.0),
                                ),
                              ),
                              focusedBorder: OutlineInputBorder(
                                borderSide: BorderSide(
                                  color: Color(0xffDFE2E6),
                                ),
                                borderRadius: BorderRadius.all(
                                  Radius.circular(30.0),
                                ),
                              ),
                              filled: true,
                              fillColor: Colors.white,
                              prefixIcon: Icon(
                                Icons.search,
                                color: Color(0xffDFE2E6),
                              ),
                              hintStyle: TextStyle(
                                color: Color(0xffDFE2E6),
                                // Adjust the top padding as needed
                                height:
                                    1.5, // Increase this value to add more top padding
                              ),
                              contentPadding: EdgeInsets.symmetric(
                                  vertical:
                                      1.0), // Adjust the vertical padding as needed
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 16.0),
                Padding(
                  padding: const EdgeInsets.only(left: 1, right: 1),
                  child: Container(
                    height: MediaQuery.of(context).size.height * 0.8,
                    child: HorizontalDataTable(
                      leftHandSideColumnWidth:
                          MediaQuery.of(context).size.width * 0.5,
                      rightHandSideColumnWidth: 100.0 *
                          columnsCount, // Adjust width for the remaining columns
                      isFixedHeader: true,
                      headerWidgets:
                          _buildHeaderWidgets(), // Custom header widgets
                      leftSideItemBuilder:
                          _buildFixedColumn, // Builds the fixed column
                      rightSideItemBuilder:
                          _buildScrollableColumns, // Builds the scrollable columns
                      itemCount: rowsCount,
                      rowSeparatorWidget: const Divider(color: Colors.grey),
                    ),
                  ),
                ),
              ],
            ),
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

  // Build the header widgets for the table
  List<Widget> _buildHeaderWidgets() {
    List<String> titles = [
      "Contest Name",
      "Questions",
      "Status",
      "Attempts",
      "Date"
    ];
    return [
      for (var i = 0; i < columnsCount; i++)
        Container(
          width: 110,
          height: 35.0,
          alignment: Alignment.center,
          child: Padding(
            padding: const EdgeInsets.only(
              top: 5.0,
            ),
            child: Text(
              " ${titles[i]}",
              style: const TextStyle(
                fontSize: 14,
                fontWeight: FontWeight.bold,
                color: Color.fromARGB(255, 48, 48, 48),
              ),
            ),
          ),
        ),
    ];
  }

  // Builds the fixed column
  Widget _buildFixedColumn(BuildContext context, int index) {
    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const ContestDetail(),
          ),
        );
      },
      child: Container(
        width: 160, // Set width for the fixed column
        height: 35.0,
        alignment: Alignment.center,
        child: Row(
          children: [
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 5),
              child: Icon(
                Icons.check_circle_outline,
                color: Color.fromARGB(207, 76, 175, 79),
                size: 24,
              ),
            ),
            Text(
              'Weekly Contest ${index + 1}',
              style: const TextStyle(
                fontSize: 14,
                color: Color.fromARGB(255, 33, 33, 33),
              ),
            ),
          ],
        ),
      ),
    );
  }

  // Builds the scrollable columns
  Widget _buildScrollableColumns(BuildContext context, int index) {
    return Row(
      children: [
        for (var i = 0; i < columnsCount; i++)
          Container(
            width: 100.0, // Adjust the width of the scrollable columns
            height: 35.0,
            alignment: Alignment.center,
            child: Text(
              'Data ${index + 1}-${i + 2}',
              style: const TextStyle(
                fontSize: 14,
                color: Color.fromARGB(255, 107, 104, 104),
              ),
            ),
          ),
      ],
    );
  }
}
