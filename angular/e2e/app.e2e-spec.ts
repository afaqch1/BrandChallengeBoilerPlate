import { BrandChallengeTemplatePage } from './app.po';

describe('BrandChallenge App', function() {
  let page: BrandChallengeTemplatePage;

  beforeEach(() => {
    page = new BrandChallengeTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
