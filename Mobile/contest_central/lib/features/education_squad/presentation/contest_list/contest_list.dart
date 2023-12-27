import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter/services.dart';
import 'package:flutter_table/table_sticky_headers.dart';

import '../../../../../../../../core/utils/circle_image.dart';
import '../../../../../../../../core/utils/img.dart';
import '../../../../../../../../core/utils/my_colors.dart';
import '../../../../../../../../core/utils/my_text.dart';
import '../contest_add/add_contest.dart';
import '../contest_stats/floating_action.dart';
import 'table.dart';

class ContestList extends StatefulWidget {
  const ContestList({super.key});

  @override
  _ContestListState createState() => _ContestListState();
}

class _ContestListState extends State<ContestList> {
  late int showingTooltip;

  @override
  void initState() {
    showingTooltip = -1;
    super.initState();
  }

  final TextEditingController _searchController = TextEditingController();

// table
  final columns = 10;
  final rows = 20;

  List<List<String>> makeData() {
    final List<List<String>> output = [];
    for (int i = 0; i < columns; i++) {
      final List<String> row = [];
      for (int j = 0; j < rows; j++) {
        row.add('L$j : T$i');
      }
      output.add(row);
    }
    return output;
  }

  /// Simple generator for column title
  List<String> makeTitleColumn() => List.generate(columns, (i) => 'Top $i');

  /// Simple generator for row title
  List<String> makeTitleRow() => List.generate(rows, (i) => 'Left $i');

  int _selectedIndex = 0;

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
                      child: const Icon(Icons.arrow_back_ios,
                          color: MyColors.grey_60),
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
                                borderRadius: BorderRadius.circular(10.0),
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
                            SizedBox(
                              width: 110,
                              height: 40,
                              child: TextFormField(
                                controller: _searchController,
                                decoration: const InputDecoration(
                                  hintText: 'Search ',
                                  enabledBorder: OutlineInputBorder(
                                    borderSide: BorderSide(
                                      color: Color(0xffDFE2E6),
                                    ),
                                    borderRadius: BorderRadius.all(
                                      Radius.circular(10.0),
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
                            const SizedBox(width: 16.0),
                            StickyHeadersTable(
                              columnsLength: 5,
                              rowsLength: 20,
                              columnsTitleBuilder: (i) => Text("Test"),
                              rowsTitleBuilder: (i) => Text("Test2"),
                              contentCellBuilder: (i, j) => Text("data[i][j]"),
                              legendCell: Text('Sticky Legend'),
                            ),
                          ],
                        ),
                      ),
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
