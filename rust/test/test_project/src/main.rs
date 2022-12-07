mod module1;
use crate::module1::TestEnum;

mod module2outer;
use crate::module2outer::module2inner::TestEnumInner;

fn main() {
    let mmx = test_project::add(1, 2);
    println!("mmx = {}", mmx);

    let m1x = module1::add(2, 3);
    println!("m1x = {}", m1x);

    let m1te2s = module1::test_enum_to_string(TestEnum::Second);
    println!("m1te2s = {}", m1te2s);

    let m2x = module2outer::module2inner::add(3, 4);
    println!("m2x = {}", m2x);

    let m2te2s = module2outer::module2inner::test_enum_inner_to_string(TestEnumInner::Third);
    println!("m2te2s = {}", m2te2s);
}
