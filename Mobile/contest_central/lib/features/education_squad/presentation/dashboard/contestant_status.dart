import 'package:flutter/material.dart';

class ScrollableTableWithButton extends StatefulWidget {
  final List<Map<dynamic, dynamic>> getContestsByFilterData;

  const ScrollableTableWithButton({
    Key? key,
    required this.getContestsByFilterData,
  }) : super(key: key);

  @override
  _ScrollableTableWithButtonState createState() =>
      _ScrollableTableWithButtonState();
}

class _ScrollableTableWithButtonState extends State<ScrollableTableWithButton> {
  final ScrollController _scrollController = ScrollController();

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.only(left: 10, right: 10, top: 20),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(8.0),
              boxShadow: const [
                BoxShadow(
                  color: Color.fromRGBO(149, 157, 165, 0.2),
                  offset: Offset(0, 8),
                  blurRadius: 24.0,
                ),
              ],
            ),
            child: SizedBox(
              width: double.infinity,
              child: SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: DataTable(
                  headingRowColor: MaterialStateColor.resolveWith(
                      (states) => Colors.grey[200]!),
                  dividerThickness: 0.4,
                  columnSpacing: 30,
                  columns: const [
                    DataColumn(
                      label: Text(
                        'CONTEST NAME',
                        style: TextStyle(
                          fontSize: 14,
                          color: Color.fromARGB(255, 107, 104, 104),
                        ),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        'DATE',
                        style: TextStyle(
                          fontSize: 14,
                          color: Color.fromARGB(255, 107, 104, 104),
                        ),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        'STATUS',
                        style: TextStyle(
                          fontSize: 14,
                          color: Color.fromARGB(255, 107, 104, 104),
                        ),
                      ),
                    ),
                  ],
                  rows: List.generate(widget.getContestsByFilterData.length,
                      (index) {
                    final contest = widget.getContestsByFilterData[index];
                    final status = contest['status'];

                    return DataRow(cells: [
                      DataCell(Text(contest['name'].toString())),
                      const DataCell(
                          Text('7 Nov,11:03')), // Replace with actual date
                      DataCell(status == 'FINISHED'
                          ? const Icon(
                              Icons.check_circle_outline_rounded,
                              color: Colors.green,
                            )
                          : const Icon(
                              Icons.rotate_right,
                              color: Color.fromARGB(255, 176, 186, 30),
                            )),
                    ]);
                  }),
                ),
              ),
            ),
          ),
        ),
        const SizedBox(
          height: 50,
        ),
      ],
    );
  }
}
