 //Sulyagina Anastasia (c) 2014
// RegExp for email parsing
module EmailChecker

let isEmail s =
    let login = "([\w\+\-]|([\w\+\-]\.[\w\+\-])){2,}"
    let domain = "(((([\w]+)\.)+(([a-zA-Z]{2})|aero|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|xxx)))"
    let expr = new System.Text.RegularExpressions.Regex("^" + login + "@" + domain + "$")
    expr.IsMatch(s)

