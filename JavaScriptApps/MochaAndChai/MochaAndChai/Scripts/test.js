/// <reference path="actual.js" />
describe('actualJS', function () {
    it('when 2 and 2 return true', function () {
        var actual = actualJS(2,2);
        expect(actual).to.equal(true);
    });
    it('when 2 and 3 return false', function () {
        var actual = actualJS(2, 3);
        expect(actual).to.equal(false);
    });
    it('when 2 and 3 return false', function () {
        var actual = actualJS(2, 3);
        expect(actual).to.equal(true);
    });
});
