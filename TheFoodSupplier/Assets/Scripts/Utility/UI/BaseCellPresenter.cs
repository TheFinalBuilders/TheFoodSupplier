using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TFS.UI
{
    /// <summary>
    /// セルの位置を調節するクラス
    /// 事前に隠せるの位置を登録しておき、タプしていないときは近くにセルに移動するように設定
    /// </summary>
    public class CellAdjaster
    {
        private readonly float LimitedLerpPixels = 10.0f;

        // TODO あとで移動方向を制限するために使用する。
        private bool isHorizontalConstrain = false;
        private bool isVertialConstrain = false;

        private List<GameObject> constrainGameObject = new List<GameObject>();

        // 現在座標からのオフセット
        public Func<Vector2,Vector2> ConvertFunc = (Vector2 vec) => vec;
        public Func<Vector2,Vector2> DeConvertFunc = (Vector2 vec) => vec;

        public CellAdjaster()
        {
        }

        public void AddConstrain(GameObject gameObject)
        {
            constrainGameObject.Add(gameObject);
        }

        public Vector2 LeapNearPosition(Vector2 pos, float T)
        {
            if (constrainGameObject.Count <= 0) {
                return pos;
            }

            // オフセットを適応
            pos = ConvertFunc(pos);

            // 一番近い座標を取得
            var minVec = FindNearestPosition(pos);

            // その位置へ徐々に移動する：オフセットを適応して
            return DeConvertFunc(Lerp(pos,minVec,T));
        }

        private Vector2 Lerp(Vector2 pos, Vector2 dest, float T)
        {
            if ((pos-dest).magnitude < LimitedLerpPixels) {
                return dest;
            }

            return Vector2.Lerp(pos, dest, T);            
        }

        private Vector2 FindNearestPosition(Vector2 center)
        {
            Vector2 minVec = Vector2.zero;
            float minValue = float.MaxValue;
            constrainGameObject.ForEach((GameObject go) =>
            {
                Vector2 vec = go.transform.localPosition;
                float value = (center - vec).magnitude;

                if (value < minValue) {
                    minVec = vec;
                    minValue = value;
                }
            });

            return minVec;
        }
    }

    /// <summary>
    /// 入力処理を行う
    /// 現状はフリックした際挙動を設定できる
    /// </summary>
    public class BaseCellPresenterInput : InputGesture
    {
        public Action<GestureInfo> flickAction = (GestureInfo info) => { };

        /// <summary>
        /// ジェスチャーの処理順番番号
        /// </summary>
        /// <value>0が一番速い、数値が大きくなると判定順番が遅くなる</value>
        public int Order { get { return 0; } }
        public bool IsGestureProcess(GestureInfo info){return true;}
        public void OnGestureDown(GestureInfo info){}
        public void OnGestureUp(GestureInfo info){}
        public void OnGestureDrag(GestureInfo info){}

        /// <summary>
        /// Flick時に呼び出されます
        /// </summary>
        /// <param name="info">Info.</param>
        public void OnGestureFlick(GestureInfo info)
        {
            flickAction(info);
        }
    }

    /// <summary>
    /// セルを使った一覧を使用する際の基底クラス
    /// セルプレファブを設定して、初期化を継承先に記載することでセルが完成
    /// </summary>
    public abstract class BaseCellPresenter<CellView, Model> : InputGestureManager
    {
        [SerializeField]
        private GameObject CellPrefab = null;

        [SerializeField]
        private float LeapT = 1.0f;

        private CellAdjaster cellAdjaster = new CellAdjaster();
        private BaseCellPresenterInput baseCellPresenterInput = new BaseCellPresenterInput();

        // Use this for initialization
        public virtual void Start()
        {
            // 要素と後ろの動く方向は異なるため TODO もっと上位の概念として外出ししてもいいかも
            cellAdjaster.ConvertFunc = (Vector2 vec) => vec * -1;
            cellAdjaster.DeConvertFunc = (Vector2 vec) => vec * -1;

            // インプットを登録
            RegisterGesture(baseCellPresenterInput);
            baseCellPresenterInput.flickAction = (GestureInfo info) =>
            {
                if (info.DragDistance.x < 0) {
                    MoveRightCell();
                }

                if (info.DragDistance.x > 0) {
                    MoveLeftCell();
                }
            };
        }

        // Update is called once per frame
        public virtual void Update()
        {
            UpdateInput();
            
            if (!Input.GetMouseButton(0)) 
            {
                var newPosition = cellAdjaster.LeapNearPosition(
                    gameObject.transform.localPosition,
                    LeapT
                );

                gameObject.transform.localPosition = new Vector3(
                    newPosition.x,
                    newPosition.y,
                    gameObject.transform.localPosition.z
                );
            }
        }

        public void MoveRightCell()
        {
            // セルの幅の半分だけ移動
            var newPosition = gameObject.transform.localPosition + new Vector3(
                - CellPrefab.GetComponent<RectTransform>().sizeDelta.x/2,
                0,
                0
            );

            gameObject.transform.localPosition = new Vector3(
                newPosition.x,
                newPosition.y,
                gameObject.transform.localPosition.z
            );            
        }

        public void MoveLeftCell()
        {
            // セルの幅の半分だけ移動
            var newPosition = gameObject.transform.localPosition + new Vector3(
                + CellPrefab.GetComponent<RectTransform>().sizeDelta.x/2,
                0,
                0
            );

            gameObject.transform.localPosition = new Vector3(
                newPosition.x,
                newPosition.y,
                gameObject.transform.localPosition.z
            );            
        }

        // セルの生成を行う
        public void AddCell(Model model)
        {
            Debug.Assert(CellPrefab != null, "cellprefab が設定されていません");

            var cell = Instantiate(CellPrefab);
            cell.transform.SetParent(transform,false);

            var view = cell.GetComponent<CellView>();

            Debug.Assert(view != null,"view が設定されていません");

            InitializeCell(view, model);

            // 座標の設定
            cellAdjaster.AddConstrain(cell);
        }

        // モデルの生成を行う
        public abstract void InitializeCell(CellView view, Model model);
    }
}