import 'package:flutter/material.dart';

class ScrollableTableWithButton extends StatefulWidget {
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

              borderRadius:
                  BorderRadius.circular(8.0), // Set your desired border radius
              boxShadow: const [
                BoxShadow(
                  color: Color.fromRGBO(149, 157, 165, 0.2), // Shadow color
                  offset: Offset(0, 8), // Offset in the x, y direction
                  blurRadius: 24.0, // Blur radius
                ),
              ],
            ),
            child: SizedBox(
              width: double.infinity, // Set width to fill available space
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
                    )),
                    DataColumn(
                        label: Text(
                      'DATE',
                      style: TextStyle(
                        fontSize: 14,
                        color: Color.fromARGB(255, 107, 104, 104),
                      ),
                    )),
                    DataColumn(
                        label: Text(
                      'STATUS',
                      style: TextStyle(
                        fontSize: 14,
                        color: Color.fromARGB(255, 107, 104, 104),
                      ),
                    )),
                    // Add more DataColumn as needed
                  ],
                  rows: const [
                    DataRow(cells: [
                      DataCell(Text('Weekly Contest 1')),
                      DataCell(Text('7 Nov,11:03')),
                      DataCell(
                        Icon(
                          Icons.check_circle_outline_rounded,
                          color: Colors.green,
                        ),
                      ),
                      // Add more DataCells as needed
                    ]),
                    DataRow(cells: [
                      DataCell(Text('Weekly Contest 1')),
                      DataCell(Text('7 Nov,11:03')),
                      DataCell(
                        Icon(
                          Icons.check_circle_outline_rounded,
                          color: Colors.green,
                        ),
                      ),
                      // Add more DataCells as needed
                    ]),
                    DataRow(cells: [
                      DataCell(Text('Weekly Contest 1')),
                      DataCell(Text('7 Nov,11:03')),
                      DataCell(
                        Icon(
                          Icons.check_circle_outline_rounded,
                          color: Colors.green,
                        ),
                      ),
                      // Add more DataCells as needed
                    ]),
                    DataRow(cells: [
                      DataCell(Text('Weekly Contest 1')),
                      DataCell(Text('7 Nov,11:03')),
                      DataCell(
                        Icon(
                          Icons.check_circle_outline_rounded,
                          color: Colors.green,
                        ),
                      ),
                      // Add more DataCells as needed
                    ]),
                    DataRow(cells: [
                      DataCell(Text('Weekly Contest 1')),
                      DataCell(Text('7 Nov,11:03')),
                      DataCell(
                        Icon(
                          Icons.check_circle_outline_rounded,
                          color: Colors.green,
                        ),
                      ),
                      // Add more DataCells as needed
                    ]),
                    DataRow(cells: [
                      DataCell(Text('Weekly Contest 1')),
                      DataCell(Text('7 Nov,11:03')),
                      DataCell(
                        Icon(
                          Icons.check_circle_outline_rounded,
                          color: Colors.green,
                        ),
                      ),
                      // Add more DataCells as needed
                    ]),
                    // Add more DataRow as needed
                  ],
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
