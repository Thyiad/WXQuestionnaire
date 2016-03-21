var userInfo = {
    name: "",
    customerType: "",
    position: "",
}

var dataDay1 = [];
var dataDay2 = [];
var app = null;

var dayIdentity = {
    day1: [
        {
            id: "d1DZ",
            text: "店长/商品",
        },
        {
            id: "d1PPJLDD",
            text: "品牌经理/督导",
        },
        {
            id: "d1CLPX",
            text: "培训/陈列",
        },
        //{
        //    id: "d1SP",
        //    text: "商品",
        //},
    ],
    day2: [
        {
            id: "d2DZ",
            text: "店长",
        },
        {
            id: "d2PPJLDD",
            text: "品牌经理/督导",
        },
        {
            id: "d2CLPX",
            text: "陈列/培训",
        },
        {
            id: "d2CL",
            text: "培训",
        },
    ]
};

var msgConst = {
    title1: "课程满意吗？",
    text1: "课程的实用性，提供有效技巧和方法", // "课程实用，提供了有效的技巧和方法",
    title2: "培训内容满意吗？",
    text2: "培训内容的丰富性、针对性",// "培训内容丰富并且具有针对性",
    title3: "培训方式满意吗？",
    text3: "培训方式的趣味性、启发性",// "培训方式有趣味并且具有启发性",
    title4: "讲师能力满意吗？",
    text4: "讲师与课程主题相关之专业能力", //"讲师拥有与课程主题相关的专业能力",
    title5: "讲师授课满意吗？",
    text5: "讲师授课语速适中、表达清晰、易于理解",
    title6: "讲师互动满意吗？",
    text6: "讲师调动学员积极参与互动", //"讲师能调动学员积极参与互动",
    title01: "培训时间满意吗？",
    text01: "培训项目的时间的安排", //"培训时间安排合理",
    title02: "现场布置满意吗？",
    text02: "现场布置安排", //"现场的布置安排恰当",
    title03: "活动设置满意吗？",
    text03: "活动设置及组织效果",//"活动设置及组织效果好",
};

var dataCommon = {
    q0: [
            {
                id: 'Q01',
                title: msgConst.title01,
                text: msgConst.text01,
            },
            {
                id: 'Q02',
                title: msgConst.title02,
                text: msgConst.text02,
            },
            {
                id: 'Q03',
                title: msgConst.title03,
                text: msgConst.text03,
            },
    ],
    q1: [
            {
                id: 'Q11',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q12',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q13',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q14',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q15',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q16',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q2: [
            {
                id: 'Q21',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q22',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q23',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q24',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q25',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q26',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q3: [
            {
                id: 'Q31',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q32',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q33',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q34',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q35',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q36',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q4: [
            {
                id: 'Q41',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q42',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q43',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q44',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q45',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q46',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q5: [
            {
                id: 'Q51',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q52',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q53',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q54',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q55',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q56',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q6: [
            {
                id: 'Q61',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q62',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q63',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q64',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q65',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q66',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q7: [
            {
                id: 'Q71',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q72',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q73',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q74',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q75',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q76',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q8: [
            {
                id: 'Q81',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q82',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q83',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q84',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q85',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q86',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
    q9: [
            {
                id: 'Q91',
                title: msgConst.title1,
                text: msgConst.text1,
            },
            {
                id: 'Q92',
                title: msgConst.title2,
                text: msgConst.text2,
            },
            {
                id: 'Q93',
                title: msgConst.title3,
                text: msgConst.text3,
            },
            {
                id: 'Q94',
                title: msgConst.title4,
                text: msgConst.text4,
            },
            {
                id: 'Q95',
                title: msgConst.title5,
                text: msgConst.text5,
            },
            {
                id: 'Q96',
                title: msgConst.title6,
                text: msgConst.text6,
            },
    ],
};

dataDay1 = [
    {
        questionType: "11",
        pageID: dayIdentity.day1[0].id,
        title: "店长/商品场D1",
        questions: [
            {
                name: "SU16 开季指引-市场推广",
                subQuestions: dataCommon.q1,
            },
            {
                name: "SU16 开季指引-新品发布",
                subQuestions: dataCommon.q2,
            },
            {
                name: "SU16 开季指引－陈列指引",
                subQuestions: dataCommon.q3
            },
            {
                name: "商品规划",
                subQuestions: dataCommon.q4
            },
            {
                name: "零售规划",
                subQuestions: dataCommon.q5
            },
            {
                name: "视觉营销管理",
                subQuestions: dataCommon.q6
            },
            {
                name: "零售日志的运用",
                subQuestions: dataCommon.q7
            },
            {
                name: "后仓管理",
                subQuestions: dataCommon.q8
            },
            {
                name: "MSP带教培训",
                subQuestions: dataCommon.q9
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "12",
        pageID: dayIdentity.day1[1].id,
        title: "品牌经理&督导D1",
        questions: [
            {
                name: "Leadership领导力",
                subQuestions: dataCommon.q1
            },
            {
                name: "零售日志的运用",
                subQuestions: dataCommon.q2
            },
            {
                name: "后仓管理",
                subQuestions: dataCommon.q3
            },
            {
                name: "MSP带教培训",
                subQuestions: dataCommon.q4
            },
            {
                name: "慧眼识人-店铺人员招聘与管理系列",
                subQuestions: dataCommon.q5
            },
            {
                name: "知人善用-优质新员工的养成",
                subQuestions: dataCommon.q6
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "13",
        pageID: dayIdentity.day1[2].id,
        title: "培训&陈列D1",
        questions: [
            {
                name: "开季指引-SU16市场推广",
                subQuestions: dataCommon.q1
            },
            {
                name: "开季指引-SU16新品发布-鞋类",
                subQuestions: dataCommon.q2
            },
            {
                name: "开季指引-SU16新品发布-服装",
                subQuestions: dataCommon.q3
            }, {
                name: "开季指引－SU16陈列指引",
                subQuestions: dataCommon.q4
            }, {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    //{
    //    questionType: "14",
    //    pageID: dayIdentity.day1[3].id,
    //    title: "商品D1",
    //    questions: [
    //        {
    //            name: "零售规划",
    //            subQuestions: dataCommon.q1
    //        },
    //        {
    //            name: "商品规划",
    //            subQuestions: dataCommon.q2
    //        },
    //        {
    //            name: "SU16市场推广",
    //            subQuestions: dataCommon.q3
    //        }, {
    //            name: "SU16新品发布-鞋",
    //            subQuestions: dataCommon.q4
    //        }, {
    //            name: "SU16新品发布-服装",
    //            subQuestions: dataCommon.q5
    //        }, {
    //            name: "项目组织安排",
    //            subQuestions: dataCommon.q0
    //        }
    //    ]
    //}
];
dataDay2 = [
    {
        questionType: "21",
        pageID: dayIdentity.day2[0].id,
        title: "店长/商品场D2",
        questions: [
            {
                name: "慧眼识人-店铺人员招聘与管理系列",
                subQuestions: dataCommon.q1,
            },
            {
                name: "知人善用-优质新员工的养成",
                subQuestions: dataCommon.q2,
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q3
            },
        ]
    },
    {
        questionType: "22",
        pageID: dayIdentity.day2[1].id,
        title: "品牌经理&督导D2",
        questions: [
            {
                name: "视觉营销管理",
                subQuestions: dataCommon.q1,
            },
            {
                name: "零售规划",
                subQuestions: dataCommon.q2,
            },
            {
                name: "商品规划",
                subQuestions: dataCommon.q3
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q4
            },
        ]
    },
    {
        questionType: "23",
        pageID: dayIdentity.day2[2].id,
        title: "陈列D2",
        questions: [
            {
                name: "开季指引－SU16陈列指引",
                subQuestions: dataCommon.q1
            },
            {
                name: "开季指引－SU16陈列实操",
                subQuestions: dataCommon.q2
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q3
            },
        ]
    },
    {
        questionType: "24",
        pageID: dayIdentity.day2[3].id,
        title: "培训D2",
        questions: [
            {
                name: "知人善用-优质新员工的养成",
                subQuestions: dataCommon.q1
            },
            {
                name: "零售日志的运用",
                subQuestions: dataCommon.q2
            },
            {
                name: "后仓管理",
                subQuestions: dataCommon.q3
            },
            {
                name: "MSP带教培训",
                subQuestions: dataCommon.q4
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q5
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    }
];

$("#customerType").picker({
    toolbarTemplate: '<header class="bar bar-nav">\
                <button class="button button-link pull-right close-picker">确定</button>\
                <h1 class="title">请选择客户类别</h1>\
                </header>',
    cols: [
      {
          textAlign: 'center',
          values: ['YY', 'Belle', '区域重点客户']
      }
    ]
});
//$("#position").picker({
//    toolbarTemplate: '<header class="bar bar-nav">\
//              <button class="button button-link pull-right close-picker">确定</button>\
//              <h1 class="title">请选择职位</h1>\
//              </header>',
//    cols: [
//      {
//          textAlign: 'center',
//          values: ['品牌经理', '督导', '店长','商品']
//      }
//    ]
//});
