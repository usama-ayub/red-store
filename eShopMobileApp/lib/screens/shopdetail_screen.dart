import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:helloworld/screens/constants.dart';

List<String> tags = [
  'Blue',
  'Shirt',
  'Full Selve',
  'Full Selve1',
  'Full Selve2'
];

class ShopDetailScreen extends StatelessWidget {
  const ShopDetailScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Stack(
      children: [
        SizedBox(
          height: MediaQuery.of(context).size.height * 0.4,
          width: double.infinity,
          child: Image.asset(
            'assets/unnamed.jpg',
            fit: BoxFit.cover,
          ),
        ),
        Padding(
            padding: EdgeInsets.symmetric(vertical: 35, horizontal: 20),
            child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  CircleAvatar(
                    backgroundColor: Colors.grey.withOpacity(0.3),
                    child: Padding(
                      padding: EdgeInsets.only(left: 5),
                      child: Icon(
                        Icons.arrow_back_ios,
                        color: whiteColor,
                      ),
                    ),
                  ),
                  CircleAvatar(
                    backgroundColor: Colors.grey.withOpacity(0.3),
                    child: Icon(
                      Icons.favorite,
                      color: whiteColor,
                    ),
                  )
                ])),
        Align(
            alignment: Alignment.bottomCenter,
            child: Container(
              // width: MediaQuery.of(context).size.width,
              height: MediaQuery.of(context).size.height * 0.7,
              padding: EdgeInsets.symmetric(vertical: 20),
              decoration: BoxDecoration(
                  color: whiteColor,
                  borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(14),
                      topRight: Radius.circular(14))),
              child: Column(children: [
                Align(
                    alignment: Alignment.centerLeft,
                    child: Padding(
                      padding: EdgeInsets.symmetric(horizontal: 20),
                      child: Text('Restaurant 01',
                          style: TextStyle(color: blackColor, fontSize: 20)),
                    )),
                SizedBox(height: 10),
                Padding(
                    padding: EdgeInsets.symmetric(horizontal: 20),
                    child: Row(
                      children: [
                        Icon(
                          Icons.star,
                          color: Colors.yellow,
                        ),
                        Text('5.0'),
                        SizedBox(width: 35),
                        Icon(
                          Icons.timer,
                          color: Colors.grey,
                        ),
                        Text('20-25 mins     * 7 km')
                      ],
                    )),
                SizedBox(height: 30),
                Padding(
                    padding: EdgeInsets.only(left: 20),
                    child: Container(
                      height: 30,
                      child: ListView.separated(
                          scrollDirection: Axis.horizontal,
                          itemCount: tags.length,
                          separatorBuilder: (context, index) =>
                              SizedBox(width: 10),
                          itemBuilder: (context, index) => Container(
                                width: 80,
                                decoration: BoxDecoration(
                                    color: blackColor,
                                    borderRadius: BorderRadius.circular(16),
                                    border: Border.all(color: whiteColor)),
                                child: Center(
                                    child: Text(tags[index],
                                        style: TextStyle(
                                            color: whiteColor, fontSize: 14))),
                              )),
                    )),
                SizedBox(height: 20),
                Expanded(
                    child: ListView.separated(
                        padding: EdgeInsets.all(0),
                        itemBuilder: (context, index) => Padding(
                              padding: EdgeInsets.symmetric(horizontal: 20),
                              child: InkWell(
                                onTap: () {},
                                child: Material(
                                  elevation: 2,
                                  borderRadius: BorderRadius.circular(16),
                                  color: Colors.white,
                                  child: Container(
                                    height: 100,
                                    decoration: BoxDecoration(
                                        borderRadius:
                                            BorderRadius.circular(16)),
                                    child: Row(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.center,
                                      children: [
                                        Image.asset('assets/unnamed.jpg',
                                            fit: BoxFit.cover),
                                        const SizedBox(
                                          width: 10,
                                        ),
                                        const Column(
                                          crossAxisAlignment:
                                              CrossAxisAlignment.start,
                                          children: [
                                            SizedBox(
                                              width: 250,
                                              child: Row(
                                                mainAxisAlignment:
                                                    MainAxisAlignment
                                                        .spaceBetween,
                                                children: [
                                                  Row(
                                                    children: [
                                                      Text(
                                                        'Restaurant 01',
                                                        style: TextStyle(
                                                            fontSize: 16,
                                                            fontWeight:
                                                                FontWeight
                                                                    .w500),
                                                      ),
                                                      SizedBox(
                                                          width:
                                                              8), // spacing between texts
                                                      Text(
                                                        '(\$7)',
                                                        style: TextStyle(
                                                            fontSize: 12,
                                                            fontWeight:
                                                                FontWeight
                                                                    .w900),
                                                      ),
                                                    ],
                                                  ),
                                                  Row(
                                                    children: [
                                                      Icon(Icons.star,
                                                          color: Colors.yellow),
                                                      SizedBox(
                                                          width:
                                                              4), // spacing between icon and rating
                                                      Text('5.0'),
                                                    ],
                                                  ),
                                                ],
                                              ),
                                            ),
                                            SizedBox(
                                              width: 250,
                                              child: Text(
                                                'Lorem Ipsum is simply dummy text of the printing and typesetting industry.',
                                                style: TextStyle(fontSize: 12),
                                                overflow: TextOverflow.ellipsis,
                                                maxLines: 2,
                                              ),
                                            ),
                                            SizedBox(height: 8),
                                            Row(
                                              children: [
                                                Material(
                                                  elevation: 2,
                                                  shape: CircleBorder(),
                                                  child: CircleAvatar(
                                                      backgroundColor:
                                                          whiteColor,
                                                      radius: 12,
                                                      child: Text('-')),
                                                ),
                                                Text(' 1 '),
                                                CircleAvatar(
                                                    backgroundColor: blackColor,
                                                    radius: 12,
                                                    child: Text(
                                                      '+',
                                                      style: TextStyle(
                                                          color: whiteColor),
                                                    ))
                                              ],
                                            )
                                          ],
                                        )
                                      ],
                                    ),
                                  ),
                                ),
                              ),
                            ),
                        separatorBuilder: (context, index) => SizedBox(
                              height: 10,
                            ),
                        itemCount: 7))
              ]),
            ))
      ],
    ));
  }
}
