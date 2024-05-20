using System;
using Code.InputControlling;

namespace Code.Multimeter
{
    public class MultimeterController: IDisposable
    {
        private MultimeterModel _multimeterModel;
        private MultimeterView _multimeterView;
        private ScrollHandler _scrollHandler;

        public MultimeterController(MultimeterModel multimeterModel, MultimeterView multimeterView, 
           ScrollHandler scrollHandler)
        {
            _multimeterModel = multimeterModel;
            _multimeterView = multimeterView;
            _scrollHandler = scrollHandler;
        }

        public void Init()
        {
            _scrollHandler.ScrollUp += OnScrollUp;
            _scrollHandler.ScrollDown += OnScrollDown;
            _multimeterView.SectionSwitched += OnSectionSwitched;
        }

        private void OnScrollUp()
        {
            _multimeterView.OnScrollUp();
        }

        private void OnScrollDown()
        {
            _multimeterView.OnScrollDown();
        }

        private void OnSectionSwitched(SectionType sectionType)
        {
            var result = _multimeterModel.GetMultimeterResult(sectionType);
            _multimeterView.ResultTextUpdate(result);
        }
        
        public void Dispose()
        {
            _scrollHandler.ScrollUp -= OnScrollUp;
            _scrollHandler.ScrollDown -= OnScrollDown;
            _multimeterView.SectionSwitched -= OnSectionSwitched;
        }
    }
}
