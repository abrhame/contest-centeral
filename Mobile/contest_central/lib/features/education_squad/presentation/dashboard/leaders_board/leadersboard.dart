import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:horizontal_data_table/horizontal_data_table.dart';

import '../../../data/datasource/remote_data_source.dart';

class LeadersBoard extends StatefulWidget {
  const LeadersBoard({super.key});

  @override
  _LeadersBoardState createState() => _LeadersBoardState();
}

class _LeadersBoardState extends State<LeadersBoard> {
  late int showingTooltip;
  final TextEditingController _searchController = TextEditingController();
  late ScrollController verticalScrollController;
  // late ScrollController _horizontalScrollController;
  bool _showFab = true;
  List<Map<dynamic, dynamic>> getRankedGroupsData = [];
  int rowsCount = 0;
  int columnsCount = 3; // Number of columns in the table
  void fetchTopGroupData() async {
    try {
      final getRankedGroupsSource = EducationSquadApiDataSource(
          baseUrl: 'https://a2sv-contest-central-api.onrender.com');
      final data = await getRankedGroupsSource.getRankedGroups();
      // print("==========> RankedGroups Data : $data");
      setState(() {
        getRankedGroupsData = data;
        rowsCount = getRankedGroupsData.length;
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

  @override
  void initState() {
    showingTooltip = -1;
    super.initState();
    fetchTopGroupData();

    verticalScrollController = ScrollController();
  }

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
          width: 180,
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
                "Leaders Board",
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
            backgroundImage: AssetImage('assets/images/no_profile.png'),
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
    );
  }

// Modify the _buildHeaderWidgets method if needed
  List<Widget> _buildHeaderWidgets() {
    List<String> titles = [
      "Group Description",
      "Generation",
      "Year",
    ];
    return [
      for (var title in titles)
        Container(
          width: 130,
          height: 35.0,
          alignment: Alignment.center,
          child: Padding(
            padding: const EdgeInsets.only(
              top: 5.0,
            ),
            child: Text(
              " $title",
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

// Modify the _buildFixedColumn method
  Widget _buildFixedColumn(BuildContext context, int index) {
    final contest = getRankedGroupsData[index];
    // final status = contest['status'];
    // print("==========> Contest Name: ${contest['name']} status : $status");

    return GestureDetector(
      onTap: () {
        // Navigator.of(context).push(
        //   MaterialPageRoute(
        //     builder: (context) => const ContestDetail(),
        //   ),
        // );
      },
      child: Container(
        width: 160, // Set width for the fixed column
        height: 35.0,
        alignment: Alignment.center,
        child: Row(
          children: [
            // Padding(
            //     padding: const EdgeInsets.symmetric(horizontal: 5),
            //     child: status == 'FINISHED'
            //         ? const Icon(
            //             Icons.check_circle_outline,
            //             color: Color.fromARGB(207, 76, 175, 79),
            //             size: 24,
            //           )
            //         : const Icon(
            //             Icons.rotate_right,
            //             color: Color.fromARGB(255, 176, 186, 30),
            //           )),

            Text(
              contest['name'],
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

// Modify the _buildScrollableColumns method
  Widget _buildScrollableColumns(BuildContext context, int index) {
    final contest = getRankedGroupsData[index];

    return Row(
      children: [
        Container(
          width: 100.0, // Adjust the width of the scrollable columns
          height: 35.0,
          alignment: Alignment.center,
          child: Text(
            contest['generation'].toString(),
            style: const TextStyle(
              fontSize: 14,
              color: Color.fromARGB(255, 107, 104, 104),
            ),
          ),
        ),
        Container(
          width: 100.0, // Adjust the width of the scrollable columns
          height: 35.0,
          alignment: Alignment.center,
          child: Text(
            contest['year'].toString(),
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
