using UnityEngine;

public class Player : TankBase
{
    private Weapon nowWeapon;
    public Transform WeaponPos;
    private Rigidbody playerRig;

    public override void Start()
    {
        GameSystem.Instance.ContinueGame();
        ChangeWeapon(0);
        playerRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!GameSystem.Instance.Gaming) return;
        if (Input.GetMouseButtonDown(0)) Fire();
    }

    private void FixedUpdate()
    {
        playerRig.velocity = transform.forward * (Input.GetAxis("Vertical") * MoveSpeed);
        transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * RotateSpeed * Time.fixedDeltaTime));
        HeadTransform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * HeadRotateSpeed * Time.fixedDeltaTime));
    }

    public void ChangeWeapon(int index)
    {
        for (int i = 0; i < WeaponPos.childCount; i++)
        {
            if (i == index)
            {
                GameObject go = WeaponPos.GetChild(i).gameObject;
                go.SetActive(true);
                nowWeapon = go.GetComponent<Weapon>();
                nowWeapon.TankBase = this;
            }
            else
            {
                WeaponPos.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public override void Fire()
    {
        nowWeapon.Fire();
    }

    public override void Wound(int attack)
    {
        base.Wound(attack);
        GameSystem.Instance.GamePanel.UpdatePlayerHp(Hp, MaxHp);
    }

    protected override void Death()
    {
        base.Death();
        GameSystem.Instance.FailPanel.ShowPanel();
        GameSystem.Instance.PauseGame();
    }
}