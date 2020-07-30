import { DerivedGenericConcreteClass } from './derived-generic-concrete-class';
import { SmthClassForTestGeneric } from './smth-class-for-test-generic';

describe('DerivedGenericConcreteClass', () => {
  it('should create an instance', () => {
    expect(new DerivedGenericConcreteClass(new SmthClassForTestGeneric(''), new SmthClassForTestGeneric(''))).toBeTruthy();
  });
});
