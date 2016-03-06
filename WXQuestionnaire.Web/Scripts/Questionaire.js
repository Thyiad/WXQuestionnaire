var userInfo = {
    name: "",
    customerType: "",
    position: "",
}

var dataDay1 = [];
var dataDay2 = [];
var app = null;

var msgConst = {
    title1: "课程实用",
    text1: "课程实用，提供了有效的技巧和方法",
    title2: "培训内容",
    text2: "培训内容丰富并且具有针对性",
    title3: "培训方式",
    text3: "培训方式有趣味并且具有启发性",
    title4: "讲师能力",
    text4: "讲师拥有与课程主题相关的专业能力",
    title5: "讲师授课",
    text5: "讲师授课语速适中、表达清晰、易于理解",
    title6: "讲师互动",
    text6: "讲师授能调动学院积极参与互动",
    title01: "培训时间",
    text01: "培训时间安排合理",
    title02: "现场布置",
    text02: "现场布置安排好",
    title03: "活动设置",
    text03: "活动设置及组织效果好",
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
};

dataDay1 = [
    {
        questionType:"11",
        pageID: "d1DZ",
        title: "店长D1",
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
                name: "慧眼识人-店铺人员招聘与管理 系列一",
                subQuestions: dataCommon.q4
            },
            {
                name: "人才储备-培养",
                subQuestions: dataCommon.q5
            },
            {
                name: "零售锦囊",
                subQuestions: dataCommon.q6
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "12",
        pageID: "d1PPJLDD",
        title: "品牌经理&督导D1",
        questions: [
            {
                name: "零售锦囊",
                subQuestions: dataCommon.q1
            },
            {
                name: "零售管理",
                subQuestions: dataCommon.q2
            },
            {
                name: "慧眼识人-店铺人员招聘与管理 系列一",
                subQuestions: dataCommon.q3
            },
            {
                name: "人才储备-培养",
                subQuestions: dataCommon.q4
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "13",
        pageID: "d1PXCL",
        title: "培训&陈列D1",
        questions: [
            {
                name: "SU16市场推广",
                subQuestions: dataCommon.q1
            },
            {
                name: "SU16新品发布-鞋",
                subQuestions: dataCommon.q2
            },
            {
                name: "SU16新品发布-服装",
                subQuestions: dataCommon.q3
            }, {
                name: "SU16陈列指引",
                subQuestions: dataCommon.q4
            }, {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "14",
        pageID: "d1SP",
        title: "商品D1",
        questions: [
            {
                name: "零售规划",
                subQuestions: dataCommon.q1
            },
            {
                name: "商品规划",
                subQuestions: dataCommon.q2
            },
            {
                name: "SU16市场推广",
                subQuestions: dataCommon.q3
            }, {
                name: "SU16新品发布-鞋",
                subQuestions: dataCommon.q4
            }, {
                name: "SU16新品发布-服装",
                subQuestions: dataCommon.q5
            }, {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    }
];
dataDay2 = [
    {
        questionType: "21",
        pageID: "d2DZ",
        title: "店长D2",
        questions: [
            {
                name: "零售规划",
                subQuestions: dataCommon.q1,
            },
            {
                name: "商品规划",
                subQuestions: dataCommon.q2,
            },
            {
                name: "视觉营销管理",
                subQuestions: dataCommon.q3
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q4
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "22",
        pageID: "d2PPJLDD",
        title: "品牌经理&督导D2",
        questions: [
            {
                name: "零售规划",
                subQuestions: dataCommon.q1,
            },
            {
                name: "商品规划",
                subQuestions: dataCommon.q2,
            },
            {
                name: "视觉营销管理",
                subQuestions: dataCommon.q3
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q4
            },
            {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "23",
        pageID: "d2PXCL",
        title: "培训&陈列D2",
        questions: [
            {
                name: "培训:人才储备-培养",
                subQuestions: dataCommon.q1
            },
            {
                name: "培训:零售锦囊",
                subQuestions: dataCommon.q2
            },
            {
                name: "VM:陈列指引",
                subQuestions: dataCommon.q3
            }, {
                name: "VM:陈列实操",
                subQuestions: dataCommon.q4
            }, {
                name: "行动计划",
                subQuestions: dataCommon.q5
            }, {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    },
    {
        questionType: "24",
        pageID: "d2CL",
        title: "陈列D2",
        questions: [
            {
                name: "VM:陈列指引",
                subQuestions: dataCommon.q1
            },
            {
                name: "VM:陈列实操",
                subQuestions: dataCommon.q2
            },
            {
                name: "行动计划",
                subQuestions: dataCommon.q3
            }, {
                name: "项目组织安排",
                subQuestions: dataCommon.q0
            }
        ]
    }
];

$("#customerType").picker({
    toolbarTemplate: '<header class="bar bar-nav">\
                <button class="button button-link pull-right close-picker">确定</button>\
                <h1 class="title">请选择职位</h1>\
                </header>',
    cols: [
      {
          textAlign: 'center',
          values: ['YY', 'Belle', '区域重点客户']
      }
    ]
});
$("#position").picker({
    toolbarTemplate: '<header class="bar bar-nav">\
              <button class="button button-link pull-right close-picker">确定</button>\
              <h1 class="title">请选择职位</h1>\
              </header>',
    cols: [
      {
          textAlign: 'center',
          values: ['店长', '品牌经理/督导', '陈列/培训']
      }
    ]
});
