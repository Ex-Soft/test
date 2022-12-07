fn main() {
    let s1 = String::from("hello");
    
    //let s2 = s1;
    //         -- value moved here
    //println!("{}, world!", s1);  // error[E0382]: borrow of moved value: `s1`
    //                       ^^ value borrowed here after move

    let s2 = s1.clone();
    println!("s1 = {}, s2 = {}", s1, s2);

    let x = 5;
    let y = x;
    println!("x = {}, y = {}", x, y);

    let s = String::from("hello");
    takes_owneship(s);
    //             - value moved here
    //println!("{}", s); // error[E0382]: borrow of moved value: `s`
    //               ^ value borrowed here after move

    makes_copy(x);
    println!("x = {}", x);

    let str1 = gives_ownership();
    let str2 = String::from("hello");
    let str3 = takes_and_gives_back(str2);
    println!("{}", str1);
    //println!("{}", str2); // error[E0382]: borrow of moved value: `str2`
    //               ^^^^ value borrowed here after move
    println!("{}", str3);

    let str = String::from("hello");
    let len = calculate_length(&str);
    println!("'{}' = {}", str, len);

    let mut str_mut = String::from("hello");
    change(&mut str_mut);
    println!("{}", str_mut);

    let r_mut1 = &mut str_mut;
    //           ------------ first mutable borrow occurs here
    //let r_mut2 = &mut str_mut; // error[E0499]: cannot borrow `str_mut` as mutable more than once at a time
    //             ^^^^^^^^^^^^ second mutable borrow occurs here
    //println!("{}, {}", r_mut1, r_mut2);
    //                   ------ first borrow later used here

    let r1 = &str_mut;
    //       -------- immutable borrow occurs here
    let r2 = &str_mut;
    //let r_mut2 = &mut str_mut; // error[E0502]: cannot borrow `str_mut` as mutable because it is also borrowed as immutable
    //           ^^^^^^^^^^^^ mutable borrow occurs here
    //println!("{}, {}, {}", r1, r2, r_mut2);
    //                       -- immutable borrow later used here

    //let reference_to_nothing = dangle();
    let no_dangle_str = no_dangle();
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

// error[E0106]: missing lifetime specifier
//fn dangle() -> &String {
//               ^ expected named lifetime parameter
//    let s = String::from("hello");
//    return &s;
//}

fn no_dangle() -> String {
    let s = String::from("hello");
    return s;
}