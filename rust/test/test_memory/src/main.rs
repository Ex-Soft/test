fn main() {
    let s1 = String::from("hello");
    
    //let s2 = s1;
    //println!("{}, world!", s1);

    let s2 = s1.clone();
    println!("s1 = {}, s2 = {}", s1, s2);

    let x = 5;
    let y = x;
    println!("x = {}, y = {}", x, y);

    let s = String::from("hello");
    takes_owneship(s);
    //println!("{}", s);

    makes_copy(x);

    let str1 = gives_ownership();
    let str2 = String::from("hello");
    let str3 = takes_and_gives_back(str2);
    println!("{}", str1);
    //println!("{}", str2);
    println!("{}", str3);

    let str = String::from("hello");
    let len = calculate_length(&str);
    println!("{}", str);
    println!("{}", len);

    let mut str_mut = String::from("hello");
    change(&mut str_mut);
    println!("{}", str_mut);

    let r_mut1 = &mut str_mut;
    //let r_mut2 = &mut str_mut;
    //println!("{}, {}", r_mut1, r_mut2);

    let r1 = &str_mut;
    let r2 = &str_mut;
    //let r_mut2 = &mut str_mut;
    //println!("{}, {}, {}", r1, r2, r_mut2);

    let reference_to_nothing = dangle();
}

fn takes_owneship(some_string: String) {
    println!("{}", some_string);
}

fn makes_copy(some_integer: i32) {
    println!("{}", some_integer);
}

fn gives_ownership() -> String {
    let some_string = String::from("hello");
    return some_string;
}

fn takes_and_gives_back(a_string: String) -> String {
    return a_string;
}

fn calculate_length(s: &String) -> usize {
    return s.len();
}

fn change(some_string: &mut String) {
    some_string.push_str(", world");
}

fn dangle() -> &String {
    let s = String::from("hello");
    return &s;
}